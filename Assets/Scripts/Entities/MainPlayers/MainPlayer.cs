using Abilities;
using Entities;
using UnityEngine;
using Weapons;

namespace Scenes
{
    public class MainPlayer : Entity
    {
        public HealWeapon CurrentHealWeapon;
        public override void ChangeAbility(IAbility ability)
        {
            currentAbility?.Remove(this);
            ability?.Choose(this);
            currentAbility = ability;
        }
        
        public override bool UseAbility(IAbility ability)
        {
            return ability.Use(this);
        }
    }
}

