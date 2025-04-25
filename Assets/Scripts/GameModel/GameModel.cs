using System;
using System.Collections.Generic;
using Entities;
using Fighting;
using Scenes.Scene;
using UnityEngine;

namespace Scenes
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();
        
        public GameObject ChosenPlayer;
        
        public List<GameObject> MainPlayers;

        public GameObject GameModelObject = GameObject.Find("GameModel");
        
        public Queue<Wave> Waves = new Queue<Wave>();
        
        public GameModel()
        {
            GameModelObject = GameObject.Find("GameModel");
            MainPlayers = new List<GameObject>();
            Waves.Enqueue(new Wave(
                new GoblinShortSword(new Vector2(5,5), 7f, "Prefabs/GoblinShortSwordPrefab", "pedik"), 
                new GoblinShortSword(new Vector2(10,5), 7f, "Prefabs/GoblinShortSwordPrefab", "loh")));
            Waves.Enqueue(new Wave(
                new GoblinShortSword(new Vector2(7,5), 7f, "Prefabs/GoblinShortSwordPrefab", "chort"), 
                new GoblinShortSword(new Vector2(9,5), 7f, "Prefabs/GoblinShortSwordPrefab", "vitalya")));
        }
    }
}