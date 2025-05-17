using System.Collections.Generic;
using Abilities;
using Entities;
using Paths;
using Scenes;
using UnityEngine;

namespace Weapons
{
    public class DamageWeapon : Weapon
    {
        public DamageWeapon(int minDamage, int maxDamage, float range, float splashRadius) : base(minDamage, maxDamage, range, splashRadius)
        {
        }

        protected override void Damage(Entity user, Entity target)
        {
            if (Random.Range(1, 20) > target.ArmorClass)
            {
                Debug.Log($"{user.Name} попадает по {target.Name}");
                var damage = Random.Range(minDamage, maxDamage);
                target.Health -= damage;
                if (target.Health <= 0) target.Health = 0;
                Debug.Log($"у {target.Name} осталось {target.Health} хп после тычки на {damage} урона");
            }
            else
            {
                Debug.Log($"{user.Name} не попадает по {target.Name}");
            }
        }

        public override bool Use(MainPlayer player)
        {
            if (player.MainActionPoint <= 0)
            {
                Debug.Log("Нет очков действия");
                return false;
            }
            var playerObj = player.GameObject;
            var attack = playerObj.GetComponent<Attack>();
            var pathController = playerObj.GetComponent<PathController>();
            if (pathController.path == null) return false;
            if (pathController.target is not null && pathController.target == player.GameObject)
            {
                Debug.Log("нельзя атаковать себя");
                return false;
            }
            attack.target = pathController.target?.GetComponent<EntityWrapper>().Entity;
            attack.pathToTarget = pathController.path;
            attack.targetPosition = (Vector3)pathController.targetPos;
            attack.enabled = true;
            return true;
        }

        public override bool Use(Enemy enemy)
        {
            if (enemy.MainActionPoint <= 0)
            {
                return false;
            }
            Entity target = null;
            List<Vector3Int> path = null;
            var minPathLenght = int.MaxValue;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var currentpath = PathFinder.BFS(enemy, this, player.GameObject.transform.position);
                if (currentpath != null && currentpath.Count < minPathLenght)
                {
                    path = currentpath;
                    minPathLenght = currentpath.Count;
                    target = player;
                }
            }

            if (path == null) return false;
            
            var attack = enemy.GameObject.GetComponent<Attack>();
            attack.target = target;
            attack.pathToTarget = path;
            attack.targetPosition = target.GameObject.transform.position;
            enemy.ChangeAbility(this);
            attack.enabled = true;
            return true;
        }
    }
}