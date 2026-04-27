using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using Weapons;

namespace Abilities
{
    public class MoveBoost : IPlayerAbility, IAbility<Enemy>
    {
        public static MoveBoost Instance { get; } = new MoveBoost();
        public Sprite Icon { get; set; } = Resources.Load<Sprite>("Icons/MoveBoost");
        public string Name { get; set; } = "Рывок";
        public string Description { get; set; } = "Увеличивает перемещение персонажа на 3 клетки";

        public void Choose(MainPlayer player)
        {
        }

        public void Remove(MainPlayer player)
        {
        }

        public bool Use(MainPlayer player)
        {
            if (player.MainActionPoint <=0) return false;
            player.GameObject.GetComponent<UsingBoost>().enabled = true;
            return true;
        }

        public void Choose(Enemy enemy)
        {
        }

        public void Remove(Enemy enemy)
        {
        }

        public bool Use(Enemy enemy)
        {
            if (enemy.MainActionPoint <=0) return false;
            enemy.ChangeAbility(this);
            enemy.GameObject.GetComponent<UsingBoost>().enabled = true;
            return true;
        }
    }
}