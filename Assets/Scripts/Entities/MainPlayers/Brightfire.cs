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
            ArmorClass = 8;
            StartPosition = new Vector2(5, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Wiz_Prefab");
            MoveSpeed = 7f;
            Name = "Brightfire";
            MaxTileCount = 9;
            var weapon1 = new HealWeapon(5, 10, 1.5f, 0f, true);
            weapon1.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon1.Name = "Концентрированное лечение";
            weapon1.Description = "Создает вокруг себя целебную ауру и направляет ее на указанную цель. Не перепутайте своего союзника с врагом";
            var weapon2 = new HealWeapon(3, 7, 10f, 2.5f, true);
            weapon2.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon2.Name = "Рассеянное лечение";
            weapon2.Description = "Концентрирует в руках целебную ауру и по земле передает ее в указанную точку. Аура рассеивается и действует по области. Будьте внимательны, попавшие в эту область враги так же получат исцеление";
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
            UI.Screen.Instance.BrightButton.interactable = isActive;
        }
    }
}