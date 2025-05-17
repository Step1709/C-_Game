using System;
using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
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
    public Vector3? targetPos;

    [SerializeField] private EntityWrapper wrapper;

    private void Start()
    {
        mainCamera = Camera.main;
        player = (MainPlayer)wrapper.Entity;
    }

     private void FixedUpdate()
     {
         var mouseWorldPos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
         var hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
         target = null;
         path = null;
         targetPos = null;
         if (player.currentAbility is NoAbility &&
             GameModel.Instance.Floor.HasTile(GameModel.Instance.Floor.WorldToCell(mouseWorldPos)))
         {
             var targetTile = GameModel.Instance.Floor.WorldToCell(mouseWorldPos);
             path = PathFinder.AStar(GameModel.Instance.Floor.WorldToCell(transform.position), targetTile)?
                 .Take(player.CurrentTileCount)
                 .ToList();
         }
         else if (player.currentAbility is Weapon)
         {
             if (hit.collider != null && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Player")))
             {
                 target = hit.collider.gameObject;
                 path = PathFinder.BFS(player, (Weapon)player.currentAbility, target.transform.position);
                 targetPos = target.transform.position;
             }
             else if (GameModel.Instance.Floor.HasTile(GameModel.Instance.Floor.WorldToCell(mouseWorldPos)))
             {
                 path = PathFinder.BFS(player, (Weapon)player.currentAbility,mouseWorldPos);
                 targetPos = mouseWorldPos;
             }
         }
    }
}
