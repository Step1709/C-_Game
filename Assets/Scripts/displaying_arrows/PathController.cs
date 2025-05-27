using System;
using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using UnityEngine;
using Fighting;
using Paths;
using Scenes;
using UI;
using Weapons;
using Screen = UI.Screen;

public class PathController : MonoBehaviour
{
    public MainPlayer player;
    private Camera mainCamera;

    public List<Vector3Int> path;
    public GameObject target;
    public Vector3? targetPos;

    [SerializeField] private EntityWrapper wrapper;
    
    private AbilityInfo abilityInfo;
    
    void OnEnable()
    {
        abilityInfo ??= Screen.Instance.AbilityInfo.GetComponent<AbilityInfo>();
        abilityInfo.pathController = this;
        Screen.Instance.AbilityInfo.SetActive(true);
    }

    void OnDisable()
    {
        if (abilityInfo != null) abilityInfo.pathController = null;
        if (Screen.Instance.AbilityInfo != null) Screen.Instance.AbilityInfo.SetActive(false);
    }
    void Start()
    {
        mainCamera = Camera.main;
        player = (MainPlayer)wrapper.Entity;
    }

     public void FixedUpdate()
     {
         var mouseWorldPos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
         target = null;
         path = null;
         targetPos = null;
         if (player.currentAbility is NoAbility &&
             GameModel.Instance.Floor.HasTile(GameModel.Instance.Floor.WorldToCell(mouseWorldPos)))
         {
             var targetTile = GameModel.Instance.Floor.WorldToCell(mouseWorldPos);
             path = PathFinder.BFS(player, x=>GameModel.Instance.Floor.WorldToCell(x) == targetTile,
                 x=>x.depth + Vector3.Distance(x.cellPosition, targetTile));
         }
         else if (player.currentAbility is Weapon)
         {
             var hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
             if (hit.collider is not null && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Player")))
             {
                 target = hit.collider.gameObject;
                 targetPos = target.transform.position;
                 var exceptColliders = Physics2D.OverlapCircleAll((Vector3)targetPos, 0.1f)
                     .ToHashSet();
                 path = PathFinder.BFS(player, 
                     x=>Vector3.Distance(x, (Vector3)targetPos) <= ((Weapon)player.currentAbility).Range 
                        && !PathFinder.IsBlocked(x, (Vector3)targetPos, gameObject, target, exceptColliders),
                     x=>x.depth + Vector3.Distance(GameModel.Instance.Floor.GetCellCenterWorld(x.cellPosition), target.transform.position));
             }
             else if (GameModel.Instance.Floor.HasTile(GameModel.Instance.Floor.WorldToCell(mouseWorldPos)))
             {
                 var exceptColliders = Physics2D.OverlapCircleAll(mouseWorldPos, 0.1f)
                     .ToHashSet();
                 path = PathFinder.BFS(player, 
                     x=>Vector3.Distance(x, mouseWorldPos) <= ((Weapon)player.currentAbility).Range 
                        && !PathFinder.IsBlocked(x, mouseWorldPos, gameObject, target, exceptColliders),
                     x=>x.depth + Vector3.Distance(GameModel.Instance.Floor.GetCellCenterWorld(x.cellPosition), mouseWorldPos));
                 targetPos = mouseWorldPos;
             }
         }
    }
}
