using System.Collections.Generic;
using Abilities;
using UnityEngine;
using Scenes;
using Weapons;

namespace Scenes
{
    public class Ashen: MainPlayer
    {
        public static Ashen Instance { get; } = new Ashen();

        private Ashen()
        {
            MaxHealth = 25;
            ArmorClass = 10;
            StartPosition = new Vector2(0.5f, 3);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Wiz_Prefab");
            MoveSpeed = 7f;
            Name = "Ashen";
            MaxTileCount = 9;
            Icon = Resources.Load<Sprite>("Icons/AshenIcon");
            var weapon1 = new DamageWeapon(9, 15, 10f, 0f, true, "Atack1_A");
            weapon1.Icon = Resources.Load<Sprite>("Icons/bow");
            weapon1.Name = "Выстрел из лука";
            weapon1.Description = "Выпускает стрелу по выбранной цели из лука";
            var weapon2 = new DamageWeapon(7, 12, 10f, 3f, true, "Atack2_A");
            weapon2.Icon = Resources.Load<Sprite>("Icons/fireball");
            weapon2.Name = "Огненный шар";
            weapon2.Description = "Создает и бросает в указанную точку огненный шар, который поражает своим пламенем большую область вокруг. Будьте острожныи и не подожгите себя и союзников!";
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
            UI.Screen.Instance.AshenButton.interactable = isActive;
        }
    }
}
