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
        
        public int MaxHealth;

        public int ArmorClass;
        
        public Vector2 StartPosition;

        public float MoveSpeed;
        
        public GameObject EntityPrefab;

        public GameObject GameObject;
        
        public string Name;

        public int MaxTileCount;
        
        public int CurrentTileCount;
        
        public int MainActionPoint;

        public void UpdateStats()
        {
            CurrentTileCount = MaxTileCount;
            MainActionPoint = 1;
        }
    }

    public abstract class Entity<T> : Entity where T : Entity<T>
    {
        public IAbility<T> currentAbility { get; protected set; }
        public List<IAbility<T>> Abilities;

        public void ChangeAbility(IAbility<T> ability)
        {
            currentAbility?.Remove((T)this);
            ability?.Choose((T)this);
            currentAbility = ability;
        }

        public bool UseAbility(IAbility<T> ability)
        {
            return ability.Use((T)this);
        }
    }
}