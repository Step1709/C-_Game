using Abilities;
using Entities;
using Scenes;
using UnityEngine;

namespace Weapons
{
    public class Weapon : IAbility
    {
        public int minDamage;
        public int maxDamage;
        public float Range;
        public float SplashRadius;

        public Weapon(int minDamage, int maxDamage, float range, float splashRadius)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            Range = range;
            SplashRadius = splashRadius;
        }

        public void Attack(Entity target)
        {
            var damage = Random.Range(minDamage, maxDamage);
            target.Health -= damage;
            Debug.Log($"у {target.Name} осталось {target.Health} хп после тычки на {damage} урона");
        }

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
            if (player.MainActionPoint > 0)
            {
                var playerObj = player.GameObject;
                var attack = playerObj.GetComponent<Attack>();
                var pathController = playerObj.GetComponent<PathController>();
                if (pathController.path != null)
                {
                    player.MainActionPoint--;
                    attack.target = pathController.target;
                    attack.pathToTarget = pathController.path;
                    attack.enabled = true;
                }
            }
            else Debug.Log("Нет очков действия");
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