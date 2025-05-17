using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class GoblinShortSword : Enemy
    {
        public GoblinShortSword(Vector2 startPos, float moveSpeed, string pathToPrefab, string name) : 
            base(startPos, moveSpeed, pathToPrefab, name)
        {
            MaxHealth = 10;
            Health = 10;
            ArmorClass = 8;
            currentAbility = NoAbility.Instance;
            MaxTileCount = 9;
            Abilities = new List<IAbility>();
            Abilities.Add(new HealWeapon(5,10, 1f, 0));
            Abilities.Add(new DamageWeapon(6, 14,1.5f, 0));
            Abilities.Add(NoAbility.Instance);
        }
    }
}