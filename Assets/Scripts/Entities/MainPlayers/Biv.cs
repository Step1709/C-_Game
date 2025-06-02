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
            ArmorClass = 12;
            StartPosition = new Vector2(-2.5f, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/Player_Mino_Prefab");
            MoveSpeed = 7f;
            Name = "Biv";
            MaxTileCount = 12;
            var weapon1 = new DamageWeapon(12, 18, 1f, 0f, false, "Broke");
            weapon1.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon1.Name = "Прямой удар";
            weapon1.Description = "Наносит мощным удар кулаком по выбранной цели. Просто, но зато эффективно";
            var weapon2 = new DamageWeapon(9, 15, 1f, 2f, false, "Broke2");
            weapon2.Icon = Resources.Load<Sprite>("UI/swordImage");
            weapon2.Name = "Удар в пол";
            weapon2.Description = "Ударяет кулаком в пол, создавая оглушающую волну вокруг. Будьте осторожны и не заденьте своих союзников";
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