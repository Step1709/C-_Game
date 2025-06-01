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

        public int TrainingComleted = PlayerPrefs.GetInt("TrainingComleted", 0);

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
        
        public List<List<Enemy>> Wave3 = new();
        
        public GameModel()
        {
            Wave1.Add(new List<Enemy>
                { new Warrior1(new Vector2(-0.5f, 9),  "warrior"), 
                    new Magic1(new Vector2(-6.5f,13),   "magic"),
                    new Magic1(new Vector2(5.5f,10),   "magic")
                });
            Wave1.Add(new List<Enemy>
            { new Magic1(new Vector2(4.5f, -9f),  "magic"), 
                new Magic1(new Vector2(-21,4),   "magic"),
                new Magic1(new Vector2(20.5f,4),   "magic")
            });
            Wave1.Add(new List<Enemy>
            { new Warrior1(new Vector2(-5.5f, 3.9f),  "warrior"), 
                new Warrior1(new Vector2(5.5f,2.9f),   "warrior"),
                new Warrior1(new Vector2(-0.5f,-4.1f),   "warrior")
            });
            
            Wave2.Add(new List<Enemy>
            {
                new Warrior2(new Vector2(-5.5f, 7.9f),   "warrior"),
                new Warrior2(new Vector2(6.5f, 8.9f),   "warrior"), 
                new Magic2(new Vector2(5.5f,14.9f),   "magic"),
                new Healer2(new Vector2(10.5f,12.9f),   "healer")
            });
            
            Wave2.Add(new List<Enemy>
            { new Warrior2(new Vector2(-5.5f, 3.9f),  "warrior"), 
                new Warrior2(new Vector2(5.5f,2.9f),   "warrior"),
                new Warrior2(new Vector2(-0.5f,-4.1f),   "warrior"),
                new Healer2(new Vector2(7.5f, 8.9f), "healer")
            });
            
            Wave2.Add(new List<Enemy>
            {new Magic2(new Vector2(4.5f, -9f),  "magic"), 
                new Magic2(new Vector2(-21,4),   "magic"),
                new Warrior2(new Vector2(20.5f,4),   "warrior"),
                new Warrior2(new Vector2(-8.5f,-9.1f),   "warrior")
            });
            
            Wave3.Add(new List<Enemy>
            {
                new Warrior3(new Vector2(-5.5f, 7.9f),   "warrior"),
                new Magic3(new Vector2(5.5f,14.9f),   "magic"),
                new Magic3(new Vector2(20.5f,4),   "magic"),
                new Healer3(new Vector2(10.5f,12.9f),   "healer")
            });
            
            Wave3.Add(new List<Enemy>
            { new Warrior3(new Vector2(-5.5f, 3.9f),  "warrior"), 
                new Warrior3(new Vector2(5.5f,2.9f),   "warrior"),
                new Magic3(new Vector2(-21,4),   "magic"),
                new Healer3(new Vector2(7.5f, 8.9f), "healer"),
            });
        }
    }
}