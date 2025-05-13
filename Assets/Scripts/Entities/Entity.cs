using System.Collections.Generic;
using Abilities;
using Scenes;
using UnityEngine;
using Weapons;

namespace Entities
{
    public abstract class Entity
    {
        public int Health;

        public int ArmorClass;
        
        public List<Weapon> Weapons;

        public Weapon CurrentWeapon;
        
        public Vector2 StartPosition;

        public float MoveSpeed;
        
        public GameObject EntityPrefab;

        public GameObject GameObject;
        
        public string Name;

        public int MaxTileCount;
        
        public int CurrentTileCount;
        
        public int MainActionPoint;
        
        public IAbility currentAbility { get; protected set; }
        
        public void Attack(Entity target)
        {
            if (Random.Range(1, 20) > target.ArmorClass)
            {
                Debug.Log($"{Name} попадает по {target.Name}");
                CurrentWeapon.Attack(target);
            }
            else
            {
                Debug.Log($"{Name} не попадает по {target.Name}");
            }

            MainActionPoint--;
        }

        public void UpdateStats()
        {
            CurrentTileCount = MaxTileCount;
            MainActionPoint = 1;
        }

        public abstract void ChangeAbility(IAbility ability);
        
        public abstract void UseAbility();
    }
}