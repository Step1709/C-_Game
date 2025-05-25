using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;
using Weapons;

namespace Paths
{
    class CellInfo
    {
        public Vector3Int cellPosition;
        public int depth;

        public CellInfo(Vector3Int cellPosition, int depth)
        {
            this.cellPosition = cellPosition;
            this.depth = depth;
        }
    }

    public class PathFinder
    {
        public static List<Vector3Int> BFS(Entity EntityLogic, Func<Vector3, bool> StopCondition)
        {
            var startCellPos = GameModel.Instance.Floor.WorldToCell(EntityLogic.GameObject.transform.position);
            var startCell = new CellInfo(startCellPos, 0);
            
            var queue = new Queue<CellInfo>();
            queue.Enqueue(startCell);
            
            var paths = new Dictionary<Vector3Int?, Vector3Int?>();
            paths[startCellPos] = null;
            
            while (queue.Count != 0)
            {
                var currentCell = queue.Dequeue();
                if (StopCondition(GameModel.Instance.Floor.GetCellCenterWorld(currentCell.cellPosition)))
                    return ReconstructPath(paths, currentCell.cellPosition);
                if (currentCell.depth >= EntityLogic.CurrentTileCount) continue;
                foreach (var neighbor in GetNeighbors(currentCell.cellPosition))
                {
                    if (CanMove(currentCell.cellPosition, neighbor) && !paths.ContainsKey(neighbor))
                    {
                        queue.Enqueue(new CellInfo(neighbor, currentCell.depth + 1));
                        paths[neighbor] = currentCell.cellPosition;
                    }
                }
            }

            return null;
        }

        private static List<Vector3Int> ReconstructPath(Dictionary<Vector3Int?, Vector3Int?> paths, Vector3Int? cellpos)
        {
            var path = new List<Vector3Int>();
            while (paths[cellpos] != null)
            {
                path.Add((Vector3Int)cellpos);
                cellpos = paths[cellpos];
            }
            path.Reverse();
            return path;
        }
        public static List<Vector3Int> AStar(Vector3Int start, Vector3Int end)
        {
            var openSet = new PriorityQueue<Vector3Int>();
            var cameFrom = new Dictionary<Vector3Int, Vector3Int>();

            var gScore = new Dictionary<Vector3Int, float>();
            var fScore = new Dictionary<Vector3Int, float>();

            openSet.Enqueue(start, 0);
            gScore[start] = 0;
            fScore[start] = Heuristic(start, end);

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();
                if (current == end)
                {
                    return ReconstructPath(cameFrom, current);
                }

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (!CanMove(current, neighbor))
                        continue;

                    var tentativeGScore = gScore[current] + 1f;
                    if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + Heuristic(neighbor, end);
                        if (!openSet.Contains(neighbor))
                            openSet.Enqueue(neighbor, fScore[neighbor]);
                    }
                }
            }

            return null;
        }
        private static float Heuristic(Vector3Int a, Vector3Int b)
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        }

        private static List<Vector3Int> ReconstructPath(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int current)
        {
            var totalPath = new List<Vector3Int> {};
            while (cameFrom.ContainsKey(current))
            {
                totalPath.Insert(0, current);
                current = cameFrom[current];
            }
            return totalPath;
        }
        
        public static bool IsWalkable(Vector3Int cellPosition)
        {
            return GameModel.Instance.Floor.HasTile(cellPosition) && !GameModel.Instance.Walls.HasTile(cellPosition);
        }

        public static bool NoWallNeigbour(Vector3Int cellPosition, Vector3Int neighbourPosition)
        {
            var d = neighbourPosition - cellPosition;
            if (d.x == 0 || d.y == 0) return true;
            var res = true;
            var neighbours = 
                GetStraightNeighbors(cellPosition).Intersect(GetStraightNeighbors(neighbourPosition));
            foreach (var neighbour in neighbours)
            {
                if (GameModel.Instance.Walls.HasTile(neighbour))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        private static bool CanMove(Vector3Int Position, Vector3Int neighbourPosition)
        {
            return IsWalkable(neighbourPosition) && NoWallNeigbour(Position, neighbourPosition);
        }
        private static IEnumerable<Vector3Int> GetNeighbors(Vector3Int cell)
        {
            foreach (var neighbour in GetStraightNeighbors(cell))
            {
                yield return neighbour;
            }
            yield return new Vector3Int(cell.x + 1, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x + 1, cell.y - 1, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y - 1, cell.z);
        }
        
        private static IEnumerable<Vector3Int> GetStraightNeighbors(Vector3Int cell)
        {
            yield return new Vector3Int(cell.x + 1, cell.y, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y, cell.z);
            yield return new Vector3Int(cell.x, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x, cell.y - 1, cell.z);
        }

        public static bool IsBlocked(Vector3 start, Vector3 targetPosition, GameObject self, GameObject target, HashSet<Collider2D> exceptColliders)
        {
            var hits = Physics2D.LinecastAll(start, targetPosition);
            foreach (var hit in hits)
            {
                if (hit.collider is not null && !hit.collider.isTrigger)
                {
                    if (hit.collider.CompareTag("Wall")) return true;
                    if ((hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                        && hit.collider.gameObject != self && hit.collider.gameObject != target &&
                        !exceptColliders.Contains(hit.collider)) return true;
                }
            }
            return false;
        }
        
        public static bool IsBlockedOnlyWalls(Vector3 start, Vector3 targetPosition)
        {
            var hits = Physics2D.LinecastAll(start, targetPosition);
            foreach (var hit in hits)
            {
                if (hit.collider is not null && hit.collider.CompareTag("Wall")) return true;
            }
            return false;
        }
    }
}