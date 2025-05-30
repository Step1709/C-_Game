using Entities;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;
using Weapons;

public class PathVisualizer : MonoBehaviour
{
    [Header("Tile Settings")]
    [SerializeField] private TileBase pathTile;
    [SerializeField] private TileBase startTile;
    [SerializeField] private TileBase radiusTile;
    
    [Header("Line Settings")]
    [SerializeField] private float lineWidth = 0.2f;
    [SerializeField] private Color lineColor = Color.red;

    private Tilemap floorTilemap;
    private Tilemap highlightTilemap;
    
    [SerializeField] private PathController pathController;
    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        floorTilemap = GameModel.Instance.Floor;
        highlightTilemap = GameModel.Instance.HighlightTilemap;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")) { color = lineColor };
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        if (highlightTilemap is null || lineRenderer is null || pathController is null) return;
        highlightTilemap.ClearAllTiles();
        lineRenderer.positionCount = 0;
        VisualizePath();
        if (pathController.targetPos.HasValue && 
            pathController.path is not null && pathController.player.currentAbility is Weapon)
        {
            var splash = ((Weapon)pathController.player.currentAbility).SplashRadius;
            if (splash > 0) splash += 0.5f;
            VisualizeAttack(splash);
        }
    }

    private void VisualizePath()
    {
        if (pathController.path == null) return;
        
        var startCell = floorTilemap.WorldToCell(transform.position);
        highlightTilemap.SetTile(startCell, startTile);
        
        foreach (var cell in pathController.path)
        {
            highlightTilemap.SetTile(cell, pathTile);
        }
    }

    private void VisualizeAttack(float radius)
    {
        var startPos = pathController.path?.Count > 0 
            ? floorTilemap.GetCellCenterWorld(pathController.path[^1])
            : transform.position;
            
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        if (pathController.targetPos != null)
        {
            lineRenderer.SetPosition(1, pathController.targetPos.Value);
            var centerCell = floorTilemap.WorldToCell(pathController.targetPos.Value);
            var radiusCells = Mathf.CeilToInt(radius / floorTilemap.cellSize.x);

            for (var x = -radiusCells; x <= radiusCells; x++)
            {
                for (var y = -radiusCells; y <= radiusCells; y++)
                {
                    var cell = centerCell + new Vector3Int(x, y, 0);
                    if (Vector3.Distance(floorTilemap.GetCellCenterWorld(cell), pathController.targetPos.Value) <=
                        radius)
                    {
                        highlightTilemap.SetTile(cell, radiusTile);
                    }
                }
            }
        }
    }

    private void OnDisable()
    {
        if (highlightTilemap != null) highlightTilemap.ClearAllTiles();
        if (lineRenderer != null) lineRenderer.positionCount = 0;
    }
}