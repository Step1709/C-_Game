using System.Collections.Generic;
using System.Linq;
using Entities;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Abilities
{
    public class NoAbility : IAbility
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
            var minPathLenght = int.MaxValue;
            var selfCellPos = GameModel.Instance.Floor.WorldToCell(enemy.GameObject.transform.position);
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var playerCellPos = GameModel.Instance.Floor.WorldToCell(player.GameObject.transform.position);
                var currentpath = PathFinder.AStar(selfCellPos, playerCellPos).Take(enemy.CurrentTileCount).ToList();
                if (currentpath.Count < minPathLenght)
                {
                    path = currentpath;
                    minPathLenght = currentpath.Count;
                }
            }

            if (path is null || path.Count <= 2) return false;
            var move = enemy.GameObject.GetComponent<Move>();
            move.path = path;
            move.isUsed = false;
            enemy.ChangeAbility(this);
            move.enabled = true;
            return true;
        }
    }
}