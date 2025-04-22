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
        
        public GameObject AshenObject;
        
        public GameObject BivObject;
        
        public MainPlayer ChosenPlayer;
        
        public List<GameObject> MainPlayers;
        
        public Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>> PathsCash;

        public GameObject GameModelObject = GameObject.Find("GameModel");
        
        public GameModel()
        {
            GameModelObject = GameObject.Find("GameModel");
            ChosenPlayer = Ashen.Instance;
            PathsCash = new Dictionary<ValueTuple<Vector3Int, Vector3Int>, List<Vector3Int>>();
            MainPlayers = new List<GameObject>();
        }
    }
}