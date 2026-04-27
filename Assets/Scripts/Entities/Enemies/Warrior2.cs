using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Warrior2 : Enemy
    {
        public Warrior2(Vector2 startPos, string name) : 
            base(startPos, name)
        {
            MaxHealth = 20;
            Health = 20;
            ArmorClass = 10;
            currentAbility = null;
            MaxTileCount = 11;
            SupportDistance = 2f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortSwordPrefab");
            Abilities = new List<IAbility<Enemy>>
            {
                new DamageWeapon(8, 15, 1.5f, 0, false, "atack_v"),
                MoveBoost.Instance,
                NoAbility.Instance
            };
        }
    }
}