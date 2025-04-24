using UnityEngine;
using Scenes;

namespace Scenes
{
    public class Biv:MainPlayer
    {
        public static Biv Instance { get; } = new Biv();

        public Biv()
        {
            StartPosition = new Vector2(5, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/PlayerPrefab");
            MoveSpeed = 7f;
            Name = "Biv";
        }
    }
}