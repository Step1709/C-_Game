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
            MaxHealth = 20;
            ArmorClass = 8;
            StartPosition = new Vector2(0.5f, 3);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Wiz_Prefab");
            MoveSpeed = 7f;
            Name = "Ashen";
            MaxTileCount = 9;
            var weapon1 = new DamageWeapon(9, 15, 10f, 0f, true);
            weapon1.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon1.Name = "Концентрированный огненный шар";
            weapon1.Description = "Атака по одиночной цели на расстоянии";
            var weapon2 = new DamageWeapon(7, 12, 10f, 3f, true);
            weapon2.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon2.Name = "Большой огненный шар";
            weapon2.Description = "Атака по области огненным шаром";
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
