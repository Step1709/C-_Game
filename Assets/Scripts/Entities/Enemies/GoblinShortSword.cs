using UnityEngine;

namespace Entities
{
    public class GoblinShortSword : Enemy
    {
        public GoblinShortSword(Vector2 startPos, float moveSpeed, string pathToPrefab, string name) : 
            base(startPos, moveSpeed, pathToPrefab, name)
        {
        }
    }
}