using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public interface IPlayerAbility : IAbility
    {
        public Sprite Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        void Choose(MainPlayer player);
        void Remove(MainPlayer player);
        bool Use(MainPlayer player);
    }
}