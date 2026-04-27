using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Magic2 : Enemy
    {
        public Magic2(Vector2 startPos, string name) : 
            base(startPos,  name)
        {
            MaxHealth = 15;
            Health = 15;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 7f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortMagePrefab");
            Abilities = new List<IAbility<Enemy>>
            {
                new DamageWeapon(7, 13, 7f, 0, false, "atack_h"),
                MoveBoost.Instance,
                NoAbility.Instance
            };
        }
    }
}