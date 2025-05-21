using System.Collections.Generic;
using System.Linq;
using Entities;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Abilities
{
    public class NoAbility : IPlayerAbility, IEnemyAbility
    {
        public static NoAbility Instance{get; private set;} = new NoAbility();
        public void Choose(MainPlayer player)
        {
            var playerObj = player.GameObject;
            playerObj.GetComponent<PathController>().enabled = true;
        }

        public void Remove(MainPlayer player)
        {
            var playerObj = player.GameObject;
            playerObj.GetComponent<PathController>().enabled = false;
        }

        public bool Use(MainPlayer player)
        {
            var playerObj = player.GameObject;
            var pathController = playerObj.GetComponent<PathController>();
            if (pathController.path is null || pathController.path.Count == 0 || player.CurrentTileCount<=0)
                return false;
            var move = playerObj.GetComponent<Move>();
            pathController.enabled = false;
            move.path = pathController.path;
            move.isUsed = false;
            move.enabled = true;
            return true;
        }

        public void Choose(Enemy enemy)
        {
            
        }

        public void Remove(Enemy enemy)
        {
            
        }

        public bool Use(Enemy enemy)
        {
            List<Vector3Int> path = null;
            MainPlayer targetPlayer = null;
            var minDistance = float.MaxValue;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var curDistance = Vector3.Distance(player.GameObject.transform.position,
                    enemy.GameObject.transform.position);
                if (curDistance < minDistance)
                {
                    targetPlayer = player;
                    minDistance = curDistance;
                }
            }
            if (targetPlayer == null) return false;
            if (Vector3.Distance(targetPlayer.GameObject.transform.position, enemy.GameObject.transform.position) >=
                enemy.SupportDistance  || PathFinder.IsBlockedOnlyWalls(enemy.GameObject.transform.position, 
                    targetPlayer.GameObject.transform.position))
            {
                path = PathFinder.AStar(GameModel.Instance.Floor.WorldToCell(enemy.GameObject.transform.position),
                    GameModel.Instance.Floor.WorldToCell(targetPlayer.GameObject.transform.position))
                    .Take(enemy.CurrentTileCount)
                    .ToList();
                var tileCount = 0;
                foreach (var tile in path)
                {
                    var tileWorldPos = GameModel.Instance.Floor.GetCellCenterWorld(tile);
                    if (Vector3.Distance(tileWorldPos, targetPlayer.GameObject.transform.position) <
                        enemy.SupportDistance
                        && !PathFinder.IsBlockedOnlyWalls(tileWorldPos, targetPlayer.GameObject.transform.position))
                    {
                        path = path.Take(tileCount).ToList();
                        break;
                    };
                    tileCount++;
                }
            }
            else
            {
                path = PathFinder.BFS(enemy, 
                    x=>Vector3.Distance(x, targetPlayer.GameObject.transform.position) > enemy.SupportDistance);
            }

            if (path is null || path.Count == 0) return false;
            var move = enemy.GameObject.GetComponent<Move>();
            move.path = path;
            move.isUsed = false;
            enemy.ChangeAbility(this);
            move.enabled = true;
            return true;
        }
    }
}