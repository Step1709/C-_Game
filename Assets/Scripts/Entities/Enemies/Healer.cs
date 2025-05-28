using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Healer : Enemy
    {
        public Healer(Vector2 startPos, float moveSpeed, string pathToPrefab, string name) :
            base(startPos, moveSpeed, pathToPrefab, name)
        {
            MaxHealth = 15;
            Health = 15;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 7f;
            Abilities = new List<IAbility>();
            Abilities.Add(new HealWeapon(6, 14, 7f, 0, false, "UI/swordImage"));
            Abilities.Add(MoveBoost.Instance);
            Abilities.Add(NoAbility.Instance);
        }
    }
}