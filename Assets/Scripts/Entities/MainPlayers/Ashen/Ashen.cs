using UnityEngine;
using Scenes;
using Weapons;

namespace Scenes
{
    public class Ashen: MainPlayer
    {
        public static Ashen Instance { get; } = new Ashen();

        public Ashen()
        {
            Health = 20;
            ArmorClass = 10;
            StartPosition = new Vector2(0, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Wiz_Prefab");
            MoveSpeed = 7f;
            Name = "Ashen";
            MaxTileCount = 15;
            CurrentWeapon = new Weapon(10, 20, 10f, 5f);
        }
        
    }
}
