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
        
        public List<IAbility> Abilities;
        
        public Vector2 StartPosition;

        public float MoveSpeed;
        
        public GameObject EntityPrefab;

        public GameObject GameObject;
        
        public string Name;

        public int MaxTileCount;
        
        public int CurrentTileCount;
        
        public int MainActionPoint;
        public IAbility currentAbility { get; protected set; }

        public void UpdateStats()
        {
            CurrentTileCount = MaxTileCount;
            MainActionPoint = 1;
        }

        public abstract void ChangeAbility(IAbility ability);
        
        public abstract bool UseAbility(IAbility ability);
    }
}