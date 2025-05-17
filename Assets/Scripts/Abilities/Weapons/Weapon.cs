using System.Collections.Generic;
using Abilities;
using Entities;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

        public void Attack(Entity user, Entity target, Vector3 targetPosition)
        {
            if (SplashRadius == 0 && target is not null)
            {
                Damage(user,target);
            }
            else
            {
                var hitColliders = Physics2D.OverlapCircleAll(targetPosition, SplashRadius);
                var damagedEntities = new HashSet<GameObject>();
                foreach (var hitCollider in hitColliders)
                {
                    if (damagedEntities.Contains(hitCollider.gameObject))
                        continue;
                    if (hitCollider.CompareTag("Player") || hitCollider.CompareTag("Enemy"))
                    {
                        damagedEntities.Add(hitCollider.gameObject);
                        Damage(user, hitCollider.gameObject.GetComponent<EntityWrapper>().Entity);
                    }
                }
            }
        }

        private void Damage(Entity user, Entity target)
        {
            if (Random.Range(1, 20) > target.ArmorClass)
            {
                Debug.Log($"{user.Name} попадает по {target.Name}");
                var damage = Random.Range(minDamage, maxDamage);
                target.Health -= damage;
                Debug.Log($"у {target.Name} осталось {target.Health} хп после тычки на {damage} урона");
            }
            else
            {
                Debug.Log($"{user.Name} не попадает по {target.Name}");
            }
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

        public bool Use(MainPlayer player)
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
            attack.target = pathController.target;
            attack.pathToTarget = pathController.path;
            attack.targetPosition = pathController.targetPos;
            attack.enabled = true;
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
            if (enemy.MainActionPoint <= 0)
            {
                return false;
            }
            GameObject target = null;
            List<Vector3Int> path = null;
            var minPathLenght = int.MaxValue;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var currentpath = PathFinder.BFS(enemy, this, player.transform.position);
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
            attack.targetPosition = target.transform.position;
            enemy.ChangeAbility(this);
            attack.enabled = true;
            return true;
        }
    }
}