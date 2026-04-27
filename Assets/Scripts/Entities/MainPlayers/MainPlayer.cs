using Abilities;
using Entities;
using UnityEngine;
using Weapons;

namespace Scenes
{
    public abstract class MainPlayer : Entity<MainPlayer>
    {
        public int AbilityIndex;

        public Sprite Icon;

        public void Update()
        {
            Health = MaxHealth;
            currentAbility = null;
        }

        public abstract void ChangeButton(bool isActive);
    }
}

