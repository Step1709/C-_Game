using System.Collections.Generic;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class PathVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private TileBase pathTile;
    [SerializeField] private TileBase startTile;
    [SerializeField] private TileBase rangeIndicatorTile;

    private Tilemap highlightTilemap;
    private PathController pathController;

    void Start()
    {
        floorTilemap = GameModel.Instance.Floor;
        highlightTilemap = GameModel.Instance.HighlightTilemap;
        pathController = GetComponent<PathController>();
    }

    void Update()
    {
        highlightTilemap.ClearAllTiles();
        VisualizePath();
    }

    private void OnDisable()
    {
        if (highlightTilemap == null) return;
        highlightTilemap.ClearAllTiles();
    }

    private void VisualizePath()
    {
        if (pathController != null && pathController.path != null)
        {
            var playerCell = floorTilemap.WorldToCell(transform.position);
            highlightTilemap.SetTile(playerCell, startTile);
            foreach (var cell in pathController.path)
            {
                highlightTilemap.SetTile(cell, pathTile);
            }
        }

        if (pathController == null || !pathController.targetPos.HasValue) return;
        var lineStart = (pathController.path != null && pathController.path.Count > 0)
            ? pathController.path[^1]
            : floorTilemap.WorldToCell(transform.position);
        var targetCell = floorTilemap.WorldToCell(pathController.targetPos.Value);
        DrawTargetLine(lineStart, targetCell);
    }

    private void DrawTargetLine(Vector3Int start, Vector3Int end)
    {
        if (rangeIndicatorTile == null)
           return;
        if (start.Equals(end))
            return;

        var lineCells = BresenhamLine(start, end);
        if(lineCells.Count > 0 && lineCells[0].Equals(start))
            lineCells.RemoveAt(0);
        foreach (var cell in lineCells)
        {
            highlightTilemap.SetTile(cell, rangeIndicatorTile);
        }
    }

    private List<Vector3Int> BresenhamLine(Vector3Int start, Vector3Int end)
    {
        var line = new List<Vector3Int>();

        var x0 = start.x;
        var y0 = start.y;
        var x1 = end.x;
        var y1 = end.y;

        var dx = Mathf.Abs(x1 - x0);
        var dy = Mathf.Abs(y1 - y0);
        var sx = (x0 < x1) ? 1 : -1;
        var sy = (y0 < y1) ? 1 : -1;
        var err = dx - dy;

        while (true)
        {
            line.Add(new Vector3Int(x0, y0, 0));
            if (x0 == x1 && y0 == y1)
                break;
            var e2 = 2 * err;
            if (e2 > -dy)
            {
                err -= dy;
                x0 += sx;
            }

            if (e2 >= dx) continue;
            err += dx;
            y0 += sy;
        }
        return line;
    }
}
