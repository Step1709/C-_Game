using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fighting;
using Paths;
using Scenes;
using Weapons;

public class PathController : MonoBehaviour
{
    public MainPlayer player;
    private Camera mainCamera;

    public List<Vector3Int> path;
    public GameObject target;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        var mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        target = null;
        path = null;
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            target = hit.collider.gameObject;
            path = PathFinder.BFS(gameObject, target);
        }
        else if (GameModel.Instance.Floor.HasTile(GameModel.Instance.Floor.WorldToCell(mouseWorldPos)))
        {
            var targetTile = GameModel.Instance.Floor.WorldToCell(mouseWorldPos);
            path = PathFinder.AStar(GameModel.Instance.Floor.WorldToCell(transform.position), targetTile)?
                .Take(player.CurrentTileCount)
                .ToList();
        }
    }
}
