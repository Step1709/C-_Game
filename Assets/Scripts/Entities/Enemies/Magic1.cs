using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Magic1 : Enemy
    {
        public Magic1(Vector2 startPos, string name) : 
            base(startPos,  name)
        {
            MaxHealth = 12;
            Health = 12;
            ArmorClass = 6;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 7f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortMagePrefab");
            Abilities = new List<IAbility>();
            Abilities.Add(new DamageWeapon(5, 10,7f, 0, false, "atack_h"));
            Abilities.Add(MoveBoost.Instance);
            Abilities.Add(NoAbility.Instance);
        }
    }
}