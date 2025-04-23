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
    }
}