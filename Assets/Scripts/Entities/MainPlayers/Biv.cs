using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Scenes;
using Weapons;

namespace Scenes
{
    public class Biv:MainPlayer
    {
        public static Biv Instance { get; } = new Biv();

        private Biv()
        {
            MaxHealth = 30;
            ArmorClass = 15;
            StartPosition = new Vector2(5, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Mino_Prefab");
            MoveSpeed = 7f;
            Name = "Biv";
            MaxTileCount = 12;
            var weapon1 = new DamageWeapon(15, 30, 1f, 0f, false);
            weapon1.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon1.Name = "Прямой удар";
            weapon1.Description = "Наносит одиночной цели прямой удар мечом";
            var weapon2 = new DamageWeapon(10, 20, 1f, 2f, false);
            weapon2.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon2.Name = "Удар с разворота";
            weapon2.Description = "Наносит мечом удар по области";
            Abilities = new List<IAbility>()
            {
                NoAbility.Instance,
                weapon1,
                weapon2,
                MoveBoost.Instance
            };
        }
        
        public override void ChangeButton(bool isActive)
        {
            UI.Screen.Instance.BivButton.interactable = isActive;
        }
        
    }
}