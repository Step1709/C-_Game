using Abilities;
using Entities;
using UnityEngine;

namespace Scenes
{
    public class MainPlayer : Entity
    {
        public override void ChangeAbility(IAbility ability)
        {
            currentAbility?.Remove(this);
            ability?.Choose(this);
            currentAbility = ability;
        }
        
        public override void UseAbility()
        {
            if (currentAbility is null)
            {
                
            }
            else
            {
                currentAbility.Use(this);
            }
        }
    }
}

