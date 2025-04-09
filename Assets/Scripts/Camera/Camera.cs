using Entities;
using UnityEngine;

namespace Scenes.Scene
{
    public class CameraClass
    {
        public static CameraClass Instance { get; }= new CameraClass();
        
        public bool IsFree;
        public Entity ChosenEntity;
        public CameraClass()
        {
            ChosenEntity = Ashen.Instance;
            IsFree = false;
        }
    }
}