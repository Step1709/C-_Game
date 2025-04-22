using System;
using System.Collections.Generic;
using Scenes.Scene;
using UnityEngine;

namespace Scenes
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();
        
        public CameraClass Camera = CameraClass.Instance;

        public Ashen Ashen = Ashen.Instance;
        public Biv Biv = Biv.Instance;

        public MainPlayer[] MainPlayers;
        
        public MainPlayer ChosenPlayer;
        
        public Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>> PathsCash;
        
        public GameModel()
        {
            MainPlayers = new MainPlayer[] { Ashen, Biv };
            ChosenPlayer = Ashen;
            PathsCash = new Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>>();
        }
    }
}