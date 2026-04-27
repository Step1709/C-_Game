using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public interface IPlayerAbility : IAbility<MainPlayer>
    {
        public Sprite Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}