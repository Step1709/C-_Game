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
        
        public MainPlayer ChosenPlayer;
        
        public List<MainPlayer> MainPlayers = new List<MainPlayer>();
        
        public List<Enemy> Enemies = new List<Enemy>();

        public GameObject GameModelObject;
        
        public Queue<Wave> Waves = new Queue<Wave>();

        public Tilemap Floor;

        public Tilemap Walls;
        
        public GameModel()
        {
            Waves.Enqueue(new Wave(
                new GoblinShortSword(new Vector2(5,5), 7f, "Prefabs/GoblinShortSwordPrefab", "pedik"), 
                new GoblinShortSword(new Vector2(10,5), 7f, "Prefabs/GoblinShortSwordPrefab", "loh")));
            Waves.Enqueue(new Wave(
                new GoblinShortSword(new Vector2(7,5), 7f, "Prefabs/GoblinShortSwordPrefab", "chort"), 
                new GoblinShortSword(new Vector2(9,5), 7f, "Prefabs/GoblinShortSwordPrefab", "vitalya")));
        }
    }
}