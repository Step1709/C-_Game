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
            Abilities = new List<IAbility>()
            {
                NoAbility.Instance,
                new DamageWeapon(15, 30, 1f, 0f, false, "UI/swordImage"),
                new DamageWeapon(10, 20, 1f, 2f, false, "UI/swordImage"),
                MoveBoost.Instance
            };
        }
        
        public override void ChangeButton(bool isActive)
        {
            UI.Screen.Instance.BivButton.interactable = isActive;
        }
        
    }
}