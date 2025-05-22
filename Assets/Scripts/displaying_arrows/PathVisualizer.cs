using System;
using System.Collections.Generic;
using Entities;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PathVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private TileBase pathTile;
    [SerializeField] private TileBase startTile;
    [SerializeField] private TileBase targetTile;
    [SerializeField] private TileBase enemyHighlightTile;
    [SerializeField] private TileBase playerHighlightTile;
    [SerializeField] private TileBase rangeIndicatorTile;

    private Tilemap highlightTilemap;
    private PathController pathController;
    private MainPlayer player;

    void Start()
    {
        floorTilemap = GameModel.Instance.Floor;
        highlightTilemap = GameModel.Instance.HighlightTilemap;
        pathController = gameObject.GetComponent<PathController>();
        player = (MainPlayer)gameObject.GetComponent<EntityWrapper>().Entity;
    }

    void FixedUpdate()
    {
        highlightTilemap.ClearAllTiles();
        VisualizePath();
        VisualizeTarget();
    }

    private void OnDisable()
    {
        if (highlightTilemap != null) highlightTilemap.ClearAllTiles();
    }

    private void VisualizePath()
    {
        if (pathController.path == null) return;
        var startCell = floorTilemap.WorldToCell(pathController.transform.position);
        highlightTilemap.SetTile(startCell, startTile);
        //DisplayMovementRange(startCell);

        if (pathController.path.Count == 0) return;
        foreach (var cell in pathController.path)
        {
            highlightTilemap.SetTile(cell, pathTile);
        }
        if (!pathController.targetPos.HasValue) return;
        
        var lastPathCell = pathController.path[^1];
        var targetCell = floorTilemap.WorldToCell(pathController.targetPos.Value);

        //if (lastPathCell == targetCell) return;
        var lineCells = GetLine(lastPathCell, targetCell);
        foreach (var cell in lineCells)
        {
            highlightTilemap.SetTile(cell, rangeIndicatorTile);
        }
    }

    private void VisualizeTarget()
    {
        if (pathController.target == null) return;

        var targetCell = floorTilemap.WorldToCell(pathController.target.transform.position);
        highlightTilemap.SetTile(targetCell, 
            pathController.target.CompareTag("Enemy") ? enemyHighlightTile : playerHighlightTile);
    }

    private void DisplayMovementRange(Vector3Int startCell)
    {
        if (player == null) return;

        var remainingMovement = player.CurrentTileCount;
        for (var i = 1; i <= remainingMovement; i++)
        {
            var offsetCell = startCell + new Vector3Int(i, 0, 0);
            if (floorTilemap.HasTile(offsetCell))
            {
                highlightTilemap.SetTile(offsetCell, rangeIndicatorTile);
            }
        }
    }

    private List<Vector3Int> GetLine(Vector3Int start, Vector3Int end)
    {
        var line = new List<Vector3Int>();

        var dx = Mathf.Abs(end.x - start.x);
        var dy = Mathf.Abs(end.y - start.y);
        var sx = start.x < end.x ? 1 : -1;
        var sy = start.y < end.y ? 1 : -1;
        var err = dx - dy;

        while (true)
        {
            if (start != end)
            {
                line.Add(start);
            }

            if (start == end) break;

            var e2 = 2 * err;
            if (e2 > -dy)
            {
                err -= dy;
                start.x += sx;
            }

            if (e2 >= dx) continue;
            err += dx;
            start.y += sy;
        }

        return line;
    }
}