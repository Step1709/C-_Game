using Abilities;
using Scenes;
using UnityEngine;

namespace Entities
{
    public class Enemy : Entity
    {
        public float SupportDistance;
        public Enemy(Vector2 startPos, float moveSpeed, string pathToPrefab, string name)
        {
            StartPosition = startPos;
            MoveSpeed = moveSpeed;
            EntityPrefab = Resources.Load<GameObject>(pathToPrefab);
            Name = name;
        }

        public override void ChangeAbility(IAbility ability)
        {
            ((IEnemyAbility)currentAbility)?.Remove(this);
            ((IEnemyAbility)ability)?.Choose(this);
            currentAbility = ability;
        }

        public override bool UseAbility(IAbility ability)
        {
            return ((IEnemyAbility)ability).Use(this);
        }

        public Enemy Copy()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }
}