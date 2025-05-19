using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Weapons
{
    public abstract class Weapon : IPlayerAbility, IEnemyAbility
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
                    if (damagedEntities.Contains(hitCollider.gameObject) 
                        || Physics2D.LinecastAll(targetPosition, hitCollider.transform.position)
                            .Any(hit=>hit.collider.CompareTag("Wall")))
                        continue;
                    if (hitCollider.CompareTag("Player") || hitCollider.CompareTag("Enemy"))
                    {
                        damagedEntities.Add(hitCollider.gameObject);
                        Damage(user, hitCollider.gameObject.GetComponent<EntityWrapper>().Entity);
                    }
                }
            }
        }

        protected abstract void Damage(Entity user, Entity target);

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

        public abstract bool Use(MainPlayer player);

        public void Choose(Enemy enemy)
        {
        }

        public void Remove(Enemy enemy)
        {
        }

        public abstract bool Use(Enemy enemy);
    }
}