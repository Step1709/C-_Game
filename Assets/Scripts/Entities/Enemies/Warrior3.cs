using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Warrior3 : Enemy
    {
        public Warrior3(Vector2 startPos, string name) : 
            base(startPos, name)
        {
            MaxHealth = 22;
            Health = 22;
            ArmorClass = 10;
            currentAbility = null;
            MaxTileCount = 11;
            SupportDistance = 2f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortSwordPrefab");
            Abilities = new List<IAbility<Enemy>>
            {
                new DamageWeapon(9, 17, 1.5f, 0, false, "atack_v"),
                MoveBoost.Instance,
                NoAbility.Instance
            };
        }
    }
}