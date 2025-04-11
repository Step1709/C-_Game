using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinder
{
    public static List<Vector3Int> FindPath(Vector3Int start, Vector3Int end, System.Func<Vector3Int, IEnumerable<Vector3Int>> getNeighbors, System.Func<Vector3Int, bool> isWalkable)
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

            foreach (var neighbor in getNeighbors(current))
            {
                if (!isWalkable(neighbor))
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
        var totalPath = new List<Vector3Int> { current };
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Insert(0, current);
        }
        return totalPath;
    }
}
