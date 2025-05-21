using System;
using System.Collections.Generic;
using Entities;
using Fighting;
using Scenes.Scene;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Scenes
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();

        public bool OnPause = false;
        
        public MainPlayer ChosenPlayer;
        
        public List<MainPlayer> MainPlayers = new List<MainPlayer>();
        
        public List<Enemy> Enemies = new List<Enemy>();

        public GameObject GameModelObject;
        
        public Queue<List<Enemy>> Waves = new ();

        public Tilemap Floor;

        public Tilemap Walls;

        public List<List<Enemy>> Wave1 = new();
        
        public List<List<Enemy>> Wave2 = new();
        
        public GameModel()
        {
            Wave1.Add(new List<Enemy>
                { new GoblinShortSword(new Vector2(5, 5), 7f, "Prefabs/GoblinShortSwordPrefab", "pedik"), 
                    new GoblinShortSword(new Vector2(10,5), 7f, "Prefabs/GoblinShortSwordPrefab", "loh") });
            
            Wave2.Add(new List<Enemy>
            {
                new GoblinShortSword(new Vector2(7,5), 7f, "Prefabs/GoblinShortSwordPrefab", "chort"), 
                new GoblinShortSword(new Vector2(9,5), 7f, "Prefabs/GoblinShortSwordPrefab", "vitalya")
            });
        }
    }
}