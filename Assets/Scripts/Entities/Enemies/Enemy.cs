using Abilities;
using Scenes;
using UnityEngine;

namespace Entities
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 startPos, float moveSpeed, string pathToPrefab, string name)
        {
            StartPosition = startPos;
            MoveSpeed = moveSpeed;
            EntityPrefab = Resources.Load<GameObject>(pathToPrefab);
            Name = name;
        }

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