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
        
        public Tilemap HighlightTilemap; 

        public List<List<Enemy>> Wave1 = new();
        
        public List<List<Enemy>> Wave2 = new();
        
        public GameModel()
        {
            Wave1.Add(new List<Enemy>
                { new Warrior(new Vector2(3, 3), 7f, "Prefabs/GoblinShortSwordPrefab", "warrior"), 
                    new Magic(new Vector2(10,5), 7f, "Prefabs/GoblinShortSwordPrefab", "magic"),
                    new Healer(new Vector2(15,5), 7f, "Prefabs/GoblinShortSwordPrefab", "healer")
                });
            
            Wave2.Add(new List<Enemy>
            {
                new Warrior(new Vector2(8, 8), 7f, "Prefabs/GoblinShortSwordPrefab", "warrior"), 
                new Magic(new Vector2(6,5), 7f, "Prefabs/GoblinShortSwordPrefab", "magic"),
                new Healer(new Vector2(13,5), 7f, "Prefabs/GoblinShortSwordPrefab", "healer")
            });
        }
    }
}