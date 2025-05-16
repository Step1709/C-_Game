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
            Health = 10;
            ArmorClass = 8;
            currentAbility = new Weapon(6, 14,5f, 0);
            MaxTileCount = 9;
            Abilities = new List<IAbility>();
            Abilities.Add(currentAbility);
            Abilities.Add(NoAbility.Instance);
        }
    }
}