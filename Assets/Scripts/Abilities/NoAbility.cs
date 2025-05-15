using Entities;
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

        public void Use(MainPlayer player)
        {
            var playerObj = player.GameObject;
            var pathController = playerObj.GetComponent<PathController>();
            if (pathController.path is not null)
            {
                var move = playerObj.GetComponent<Move>();
                move.path = pathController.path;
                move.isUsed = false;
                move.enabled = true;
            }
        }

        public void Choose(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        public void Use(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}