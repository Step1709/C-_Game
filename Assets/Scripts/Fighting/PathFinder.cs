using System.Collections.Generic;
using System.Linq;
using Entities;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Fighting
{
    class CellInfo
    {
        public Vector3Int cellPosition;
        public int depth;
        public CellInfo previous;

        public CellInfo(Vector3Int cellPosition, int depth, CellInfo previous)
        {
            this.cellPosition = cellPosition;
            this.depth = depth;
            this.previous = previous;
        }
    }
    public class PathFinder
    {
        public static List<Vector3Int> FindPath(GameObject activeEntity, GameObject targetEntity)
        {
            var activeEntityLogic = activeEntity.GetComponent<EntityWrapper>().Entity;
            var weapon = activeEntityLogic.CurrentWeapon;
            
            var startCellPos = GameModel.Instance.Floor.WorldToCell(activeEntity.transform.position);
            var startCell = new CellInfo(startCellPos, 0, null);
            
            var queue = new Queue<CellInfo>();
            queue.Enqueue(startCell);
            
            var visited = new HashSet<Vector3Int>();
            visited.Add(startCellPos);
            
            while (queue.Count != 0)
            {
                var currentCell = queue.Dequeue();
                if (Vector3.Distance(currentCell.cellPosition, targetEntity.transform.position) <= weapon.Range &&
                    !IsBlocked(currentCell.cellPosition, targetEntity.transform.position))
                    return ReconstructPath(currentCell);
                if (currentCell.depth >= activeEntityLogic.CurrentTileCount) continue;
                foreach (var neighbor in GetNeighbors(currentCell.cellPosition))
                {
                    if (CanMove(currentCell.cellPosition, neighbor) && !visited.Contains(neighbor))
                    {
                        queue.Enqueue(new CellInfo(neighbor, currentCell.depth + 1, currentCell));
                        visited.Add(neighbor);
                    }
                }
            }

            return null;
        }

        private static List<Vector3Int> ReconstructPath(CellInfo cell)
        {
            var path = new List<Vector3Int>();
            while (cell != null)
            {
                path.Add(cell.cellPosition);
                cell = cell.previous;
            }
            return path;
        }
        
        private static bool IsWalkable(Vector3Int cellPosition)
        {
            return GameModel.Instance.Floor.HasTile(cellPosition) && !GameModel.Instance.Walls.HasTile(cellPosition);
        }

        private static bool NoWallNeigbour(Vector3Int cellPosition, Vector3Int neighbourPosition)
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

        private static bool IsBlocked(Vector3 start, Vector3 end)
        {
            var hits = Physics2D.LinecastAll(start, end);
            var collider = GameModel.Instance.Floor.GetComponent<Collider2D>();
            foreach (var hit in hits)
            {
                if (hit.collider == collider) return true;
            }
            return false;
        }
    }
}