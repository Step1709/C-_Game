using Entities;
using UnityEngine;

namespace Scenes.Scene
{
    public class CameraClass
    {
        public Vector2 Position;
        public bool IsFree;

        public CameraClass()
        {
            IsFree = false;
        }
    }
}