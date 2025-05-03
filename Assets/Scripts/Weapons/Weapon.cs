using Entities;
using UnityEngine;

namespace Weapons
{
    public class Weapon
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
    }
}