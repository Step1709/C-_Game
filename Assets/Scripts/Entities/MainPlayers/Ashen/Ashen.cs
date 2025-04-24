using UnityEngine;
using Scenes;

namespace Scenes
{
    public class Ashen: MainPlayer
    {
        public static Ashen Instance { get; } = new Ashen();

        public Ashen()
        {
            StartPosition = new Vector2(0, 0);
            EntityPrefab = Resources.Load<GameObject>("Prefabs/PlayerPrefab");
            MoveSpeed = 7f;
            Name = "Ashen";
        }
        
    }
}
