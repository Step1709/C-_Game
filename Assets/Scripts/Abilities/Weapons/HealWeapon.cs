using System.Collections.Generic;
using Abilities;
using Entities;
using Paths;
using Scenes;
using UnityEngine;

namespace Weapons
{
    public class HealWeapon : Weapon
    {
        public HealWeapon(int minDamage, int maxDamage, float range, float splashRadius) : base(minDamage, maxDamage, range, splashRadius)
        {
        }

        protected override void Damage(Entity user, Entity target)
        {
            var damage = Random.Range(minDamage, maxDamage);
            target.Health += damage;
            if (target.Health >=target.MaxHealth) target.Health = target.MaxHealth;
            Debug.Log($"у {target.Name} осталось {target.Health} хп после хила на {damage} от {user.Name}");
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
            attack.target = pathController.target?.GetComponent<EntityWrapper>().Entity;
            attack.pathToTarget = pathController.path;
            attack.targetPosition = pathController.targetPos;
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
            var minHealth = int.MaxValue;
            foreach (var entity in GameModel.Instance.Enemies)
            {
                var currentpath = PathFinder.BFS(enemy, this, entity.GameObject.transform.position);
                if (currentpath != null && entity.Health <= 5 && entity.Health<=minHealth)
                {
                    path = currentpath;
                    minHealth = entity.Health;
                    target = entity;
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