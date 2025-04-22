using Entities;
using UnityEngine;

namespace Scenes.Scene
{
    public class CameraClass
    {
        public static CameraClass Instance { get; }= new CameraClass();
        
        public GameObject ChosenEntity;
        
        public bool IsFree;
        public CameraClass()
        {
            IsFree = false;
        }
    }
}