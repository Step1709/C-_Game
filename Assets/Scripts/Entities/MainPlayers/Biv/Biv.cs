using UnityEngine;
using Scenes;
using Weapons;

namespace Scenes
{
    public class Biv:MainPlayer
    {
        public static Biv Instance { get; } = new Biv();

        public Biv()
        {
            MaxHealth = 30;
            ArmorClass = 15;
            StartPosition = new Vector2(5, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Mino_Prefab");
            MoveSpeed = 7f;
            Name = "Biv";
            MaxTileCount = 15;
            CurrentWeapon = new DamageWeapon(15, 30, 1f, 0f, false);
            CurrentHealWeapon = new HealWeapon(10, 15, 1.5f, 0, false);
        }

        public override void Update()
        {
            Health = MaxHealth;
            currentAbility = null;
        }
        
        public override void ChangeButton(bool isActive)
        {
            UI.Screen.Instance.BivButton.interactable = isActive;
        }
        
    }
}