using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Healer2 : Enemy
    {
        public Healer2(Vector2 startPos,  string name) :
            base(startPos,  name)
        {
            MaxHealth = 10;
            Health = 10;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 10f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortHealerPrefab");
            Abilities = new List<IAbility>();
            Abilities.Add(new HealWeapon(4, 7, 7f, 0, false, "atack_heal"));
            Abilities.Add(MoveBoost.Instance);
            Abilities.Add(NoAbility.Instance);
        }
    }
}