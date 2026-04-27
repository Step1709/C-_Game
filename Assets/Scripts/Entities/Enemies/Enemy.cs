using Abilities;
using Scenes;
using UnityEngine;

namespace Entities
{
    public class Enemy : Entity<Enemy>
    {
        public float SupportDistance;
        public Enemy(Vector2 startPos,  string name)
        {
            StartPosition = startPos;
            Name = name;
        }
        public Enemy Copy()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }
}