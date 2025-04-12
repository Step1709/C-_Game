using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Scene
{
    public class SceneClass
    {
        public Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>> PathsCash;
        public SceneClass()
        {
            PathsCash = new Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>>();
        }
    }
}