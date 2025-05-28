using System.Collections.Generic;
using Abilities;
using Scenes;
using UnityEngine;
using Weapons;

namespace Entities.MainPlayers
{
    public class Brightfire : MainPlayer
    {
        public static Brightfire Instance { get; } = new Brightfire();

        private Brightfire()
        {
            MaxHealth = 20;
            ArmorClass = 10;
            StartPosition = new Vector2(10, 3);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Wiz_Prefab");
            MoveSpeed = 7f;
            Name = "Brightfire";
            MaxTileCount = 9;
            Abilities = new List<IAbility>()
            {
                NoAbility.Instance,
                new HealWeapon(10, 20, 1.5f, 0f, true, "UI/swordImage"),
                new HealWeapon(5, 10, 10f, 2.5f, true, "UI/swordImage"),
                MoveBoost.Instance
            };
        }
        
        public override void ChangeButton(bool isActive)
        {
            UI.Screen.Instance.BrightButton.interactable = isActive;
        }
    }
}