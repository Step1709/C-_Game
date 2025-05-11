using UnityEngine;
using Weapons;

namespace Entities
{
    public class GoblinShortSword : Enemy
    {
        public GoblinShortSword(Vector2 startPos, float moveSpeed, string pathToPrefab, string name) : 
            base(startPos, moveSpeed, pathToPrefab, name)
        {
            Health = 10;
            ArmorClass = 8;
            CurrentWeapon = new Weapon(6, 14,1.2f, 0);
            MaxTileCount = 9;
        }
    }
}