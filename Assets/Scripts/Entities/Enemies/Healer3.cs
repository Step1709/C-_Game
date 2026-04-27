using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Healer3 : Enemy
    {
        public Healer3(Vector2 startPos,  string name) :
            base(startPos,  name)
        {
            MaxHealth = 13;
            Health = 13;
            ArmorClass = 8;
            currentAbility = null;
            MaxTileCount = 9;
            SupportDistance = 10f;
            MoveSpeed = 7f;
            EntityPrefab = Resources.Load<GameObject>("Prefabs/GoblinShortHealerPrefab");
            Abilities = new List<IAbility<Enemy>>
            {
                new HealWeapon(6, 9, 7f, 0, false, "atack_heal"),
                MoveBoost.Instance,
                NoAbility.Instance
            };
        }
    }
}