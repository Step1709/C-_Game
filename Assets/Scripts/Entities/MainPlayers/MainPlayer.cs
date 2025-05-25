using Abilities;
using Entities;
using UnityEngine;
using Weapons;

namespace Scenes
{
    public abstract class MainPlayer : Entity
    {
        public HealWeapon CurrentHealWeapon;
        public override void ChangeAbility(IAbility ability)
        {
            ((IPlayerAbility)currentAbility)?.Remove(this);
            ((IPlayerAbility)ability)?.Choose(this);
            currentAbility = ability;
        }
        
        public override bool UseAbility(IAbility ability)
        {
            return ((IPlayerAbility)ability).Use(this);
        }
        
        public abstract void Update();

        public abstract void ChangeButton(bool isActive);
    }
}

