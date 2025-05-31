using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Warrior : Enemy
    {
        public Warrior(Vector2 startPos, string name) : 
            base(startPos, name)
        {
            MaxHealth = 20;
            Health = 20;
            ArmorClass = 12;
            currentAbility = null;
            MaxTileCount = 12;
            SupportDistance = 2f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortSwordPrefab");
            Abilities = new List<IAbility>();
            Abilities.Add(new DamageWeapon(6, 14,1.5f, 0, false));
            Abilities.Add(MoveBoost.Instance);
            Abilities.Add(NoAbility.Instance);
        }
    }
}