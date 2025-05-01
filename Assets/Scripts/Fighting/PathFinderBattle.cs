using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Fighting
{
    public static class PathFinderBattle
    {
        private const int AvailableMovement = 5;
        
        public static List<Vector3Int> FindPath(
            GameObject activeEntity,
            GameObject targetEntity,
            Weapon weapon,
            Func<Vector3Int, IEnumerable<Vector3Int>> getNeighbors,
            Func<Vector3Int, Vector3Int, bool> CanMove)
        {
            var activePos = Vector3Int.FloorToInt(activeEntity.transform.position);
            var targetPos = Vector3Int.FloorToInt(targetEntity.transform.position);
            if (Vector3.Distance(activePos, targetPos) <= weapon.Range)
            {
                return new List<Vector3Int>();
            }
            
            var candidateTargets = new List<Vector3Int>();
            var rangeCeil = Mathf.CeilToInt(weapon.Range);
            for (var x = -rangeCeil; x <= rangeCeil; x++)
            {
                for (var y = -rangeCeil; y <= rangeCeil; y++)
                {
                    var candidate = new Vector3Int(targetPos.x + x, targetPos.y + y, targetPos.z);
                    if (!(Vector3.Distance(candidate, targetPos) <= weapon.Range)) continue;
                    if (candidate == targetPos || CanMove(targetPos, candidate))
                    {
                        candidateTargets.Add(candidate);
                    }
                }
            }

            List<Vector3Int> bestPath = null;
            var bestPathLength = int.MaxValue;
            foreach (var candidate in candidateTargets)
            {
                var path = BFSPath(activePos, candidate, getNeighbors, CanMove, AvailableMovement);
                if (path != null && path.Count < bestPathLength)
                {
                    bestPath = path;
                    bestPathLength = path.Count;
                }
            }
            
            return bestPath;
        }
        private static List<Vector3Int> BFSPath(
            Vector3Int start,
            Vector3Int target,
            Func<Vector3Int, IEnumerable<Vector3Int>> getNeighbors,
            Func<Vector3Int, Vector3Int, bool> CanMove,
            int maxDepth)
        {
            var queue = new Queue<Vector3Int>();
            var fromDirection = new Dictionary<Vector3Int, Vector3Int>();
            var depth = new Dictionary<Vector3Int, int>();

            queue.Enqueue(start);
            depth[start] = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == target)
                {
                    return ReconstructPath(fromDirection, start, target);
                }

                var currentDepth = depth[current];
                if (currentDepth >= maxDepth)
                {
                    continue;
                }

                foreach (var neighbor in getNeighbors(current))
                {
                    if (!CanMove(current, neighbor))
                    {
                        continue;
                    }

                    if (!depth.ContainsKey(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        depth[neighbor] = currentDepth + 1;
                        fromDirection[neighbor] = current;
                    }
                }
            }

            return null;
        }
        private static List<Vector3Int> ReconstructPath(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int start, Vector3Int target)
        {
            var path = new List<Vector3Int>();
            var current = target;
            while (current != start)
            {
                path.Add(current);
                current = cameFrom[current];
            }
            path.Reverse();
            return path;
        }
    }
}