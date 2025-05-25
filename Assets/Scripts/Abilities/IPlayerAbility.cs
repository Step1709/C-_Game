using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public interface IPlayerAbility : IAbility
    {
        public Sprite Image { get; set; }
        void Choose(MainPlayer player);
        void Remove(MainPlayer player);
        bool Use(MainPlayer player);
    }
}