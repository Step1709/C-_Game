using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TailMap
{
    public class TailGraph:MonoBehaviour
    {
        public Tilemap tilemap;
        public float moveSpeed = 5f;
    public bool IsWalkable(Vector3Int cellPosition)
    {
        return tilemap.HasTile(cellPosition);
    }
    public IEnumerable<Vector3Int> GetNeighbors(Vector3Int cell)
    {
        yield return new Vector3Int(cell.x + 1, cell.y, cell.z);
        yield return new Vector3Int(cell.x - 1, cell.y, cell.z);
        yield return new Vector3Int(cell.x, cell.y + 1, cell.z);
        yield return new Vector3Int(cell.x, cell.y - 1, cell.z);
        yield return new Vector3Int(cell.x + 1, cell.y + 1, cell.z);
        yield return new Vector3Int(cell.x + 1, cell.y - 1, cell.z);
        yield return new Vector3Int(cell.x - 1, cell.y + 1, cell.z);
        yield return new Vector3Int(cell.x - 1, cell.y - 1, cell.z);
    }


    private List<Vector3> pathWorldPositions;
    private int currentTargetIndex = 0;
    private bool isMoving = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            var targetCell = tilemap.WorldToCell(mouseWorldPos);
            var startCell = tilemap.WorldToCell(transform.position);
            var path = AStarPathfinder.FindPath(startCell, targetCell, GetNeighbors, IsWalkable);
            if (path != null && path.Count > 0)
            {
                pathWorldPositions = new List<Vector3>();
                foreach (var cell in path)
                {
                    pathWorldPositions.Add(tilemap.GetCellCenterWorld(cell));
                }
                currentTargetIndex = 0;
                isMoving = true;
            }
        }

        if (isMoving && pathWorldPositions != null && pathWorldPositions.Count > 0)
        {
            var targetPosition = pathWorldPositions[currentTargetIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                currentTargetIndex++;
                if (currentTargetIndex >= pathWorldPositions.Count)
                {
                    isMoving = false;
                }
            }
        }
    }
    }
}