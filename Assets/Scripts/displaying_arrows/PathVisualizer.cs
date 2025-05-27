using Entities;
using Scenes;
using UnityEngine;
using UnityEngine.Tilemaps;
using Weapons;

[RequireComponent(typeof(Tilemap))]
public class PathVisualizer : MonoBehaviour
{
    [Header("Tile Settings")]
    [SerializeField] private TileBase pathTile;
    [SerializeField] private TileBase startTile;
    [SerializeField] private TileBase splashRadiusTile;
    
    [Header("Line Settings")]
    [SerializeField] private Material lineMaterial;
    [SerializeField] private float lineWidth = 0.1f;
    
    private Tilemap floorTilemap;
    private Tilemap highlightTilemap;
    private PathController pathController;
    private MainPlayer player;
    private LineRenderer lineRenderer;

    private void Start()
    {
        InitializeLineRenderer();
    }

    private void InitializeLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = lineMaterial != null ? lineMaterial : new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.red;
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        if (!ValidateComponents()) return;
        
        ClearVisualizations();
        VisualizeMovementPath();
        
        if (ShouldShowAttack())
        {
            VisualizeAttack();
        }
    }

    private bool ValidateComponents()
    {
        if (floorTilemap == null) floorTilemap = GameModel.Instance.Floor;
        if (highlightTilemap == null) highlightTilemap = GameModel.Instance.HighlightTilemap;
        if (pathController == null) pathController = GetComponent<PathController>();
        if (player == null) player = GetComponent<EntityWrapper>().Entity as MainPlayer;
        
        return floorTilemap != null && highlightTilemap != null && pathController != null && player != null;
    }

    private void ClearVisualizations()
    {
        if (highlightTilemap != null) 
            highlightTilemap.ClearAllTiles();
        
        if (lineRenderer != null) 
            lineRenderer.positionCount = 0;
    }

    private bool ShouldShowAttack()
    {
        return pathController.targetPos.HasValue && 
               player.currentAbility is Weapon;
    }

    private void VisualizeMovementPath()
    {
        if (pathController.path == null) return;
        
        var playerCell = floorTilemap.WorldToCell(transform.position);
        highlightTilemap.SetTile(playerCell, startTile);
        
        foreach (var cell in pathController.path)
        {
            highlightTilemap.SetTile(cell, pathTile);
        }
    }

    private void VisualizeAttack()
    {
        var weapon = (Weapon)player.currentAbility;
        var attackOrigin = GetAttackOrigin();
        var targetPos = pathController.targetPos.Value;

        DrawAttackLine(attackOrigin, targetPos);
        HighlightSplashRadius(targetPos, weapon.SplashRadius);
    }

    private Vector3 GetAttackOrigin()
    {
        return pathController.path?.Count > 0 
            ? floorTilemap.GetCellCenterWorld(pathController.path[^1])
            : transform.position;
    }

    private void DrawAttackLine(Vector3 start, Vector3 end)
    {
        if (lineRenderer == null) return;
        
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private void HighlightSplashRadius(Vector3 center, float radius)
    {
        if (splashRadiusTile == null || floorTilemap == null || highlightTilemap == null) return;

        var centerCell = floorTilemap.WorldToCell(center);
        var radiusInCells = Mathf.CeilToInt(radius / floorTilemap.cellSize.x);

        for (var x = -radiusInCells; x <= radiusInCells; x++)
        {
            for (var y = -radiusInCells; y <= radiusInCells; y++)
            {
                var cell = centerCell + new Vector3Int(x, y, 0);
                var cellCenter = floorTilemap.GetCellCenterWorld(cell);
                
                if (Vector3.Distance(cellCenter, center) <= radius)
                {
                    highlightTilemap.SetTile(cell, splashRadiusTile);
                }
            }
        }
    }

    private void OnDisable()
    {
        ClearVisualizations();
    }
}