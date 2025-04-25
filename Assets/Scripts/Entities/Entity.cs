using System.Collections.Generic;
using Scenes;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Entity
    {
        public List<Weapon> Weapons;

        public Weapon CurrentWeapon;
        
        public Vector2 StartPosition;

        public float MoveSpeed;
        
        public GameObject EntityPrefab;
        
        public string Name;
    }
}