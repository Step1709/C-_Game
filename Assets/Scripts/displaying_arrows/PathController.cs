using System;
using System.Collections.Generic;
using UnityEngine;
using Fighting;
using Weapons;

public class PathController : MonoBehaviour
{
    public int availableMovement = 5;
    public Weapon equippedWeapon;
    public PathRenderer pathRenderer; 
    public FightManager fightManager; 

    private Camera mainCamera;
    private GameObject currentHoveredEnemy;
    private IEnumerable<Vector3Int> GetNeighbors(Vector3Int pos)
    {
        yield return new Vector3Int(pos.x + 1, pos.y, pos.z);
        yield return new Vector3Int(pos.x - 1, pos.y, pos.z);
        yield return new Vector3Int(pos.x, pos.y + 1, pos.z);
        yield return new Vector3Int(pos.x, pos.y - 1, pos.z);
    }
    private bool CanMove(Vector3Int Position, Vector3Int neighbourPosition)
    {
        return Paths.PathFinder.IsWalkable(neighbourPosition) && Paths.PathFinder.NoWallNeigbour(Position, neighbourPosition);
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        var mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        currentHoveredEnemy = null;
        List<Vector3Int> foundPath = null;
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                var enemy = hit.collider.gameObject;
                currentHoveredEnemy = enemy;
                var highlighter = enemy.GetComponent<EnemyHighlighter>();
                if (highlighter != null)
                {
                    highlighter.SetHighlight(true);
                }
                foundPath = PathFinderBattle.FindPath(gameObject, enemy, equippedWeapon, GetNeighbors, CanMove);
            }
            else if (hit.collider.CompareTag("Tile"))
            {
                var targetTile = Vector3Int.FloorToInt(hit.collider.transform.position);
                foundPath = PathFinderBattle.BFSPath(Vector3Int.FloorToInt(transform.position), targetTile, GetNeighbors, CanMove, availableMovement);
            }
        }
        if (foundPath == null)
        {
            if (currentHoveredEnemy != null)
            {
                var highlighter = currentHoveredEnemy.GetComponent<EnemyHighlighter>();
                if (highlighter != null)
                {
                    highlighter.SetHighlight(false);
                }
            }
            pathRenderer.ClearPath();
        }
        else
        {
            pathRenderer.RenderPath(foundPath);
        }
    }
}
