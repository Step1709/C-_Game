using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Warrior1 : Enemy
    {
        public Warrior1(Vector2 startPos, string name) : 
            base(startPos, name)
        {
            MaxHealth = 15;
            Health = 15;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 11;
            SupportDistance = 2f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortSwordPrefab");
            Abilities = new List<IAbility<Enemy>>
            {
                new DamageWeapon(6, 13, 1.5f, 0, false, "atack_v"),
                MoveBoost.Instance,
                NoAbility.Instance
            };
        }
    }
}