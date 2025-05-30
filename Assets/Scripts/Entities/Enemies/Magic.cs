using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Magic : Enemy
    {
        public Magic(Vector2 startPos, string name) : 
            base(startPos,  name)
        {
            MaxHealth = 15;
            Health = 15;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 7f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortSwordPrefab");
            Abilities = new List<IAbility>();
            Abilities.Add(new DamageWeapon(6, 14,7f, 0, false, "UI/swordImage"));
            Abilities.Add(MoveBoost.Instance);
            Abilities.Add(NoAbility.Instance);
        }
    }
}