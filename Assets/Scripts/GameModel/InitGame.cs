using System.Collections.Generic;
using Abilities;
using Entities;
using Entities.MainPlayers;
using Scenes.Scene;
using TailMap;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Scenes
{
    public class InitGame : MonoBehaviour
    {
        void Awake()
        {
            GameModel.Instance.GameModelObject = GameObject.Find("GameModel");
            GameModel.Instance.Floor =  GameObject.Find("Floor").GetComponent<Tilemap>();
            GameModel.Instance.Walls = GameObject.Find("Walls").GetComponent<Tilemap>();
            GameModel.Instance.MainPlayers = new List<MainPlayer>();
            GameModel.Instance.MainPlayers.Add(Ashen.Instance);
            InitPlayer(Ashen.Instance);
            GameModel.Instance.MainPlayers.Add(Biv.Instance);
            InitPlayer(Biv.Instance);
            GameModel.Instance.ChosenPlayer = Ashen.Instance;
            CameraClass.Instance.ChosenEntity = GameModel.Instance.ChosenPlayer.GameObject;
        }

        private GameObject InitPlayer(MainPlayer logic)
        {
            var player = Instantiate(logic.EntityPrefab, logic.StartPosition, Quaternion.identity);
            player.name = logic.Name;
            var wrapper = player.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
            var baseHandler = player.GetComponent<PlayerBaseHandler>();
            baseHandler.mainPlayer = logic;
            var pathController = player.GetComponent<PathController>();
            pathController.player = logic;
            var playerFightController = player.GetComponent<PlayerFightController>();
            playerFightController.player = logic;
            var move = player.GetComponent<Move>();
            move.self = logic;
            var attack = player.GetComponent<Attack>();
            attack.self = logic;
            logic.GameObject = player;
            return player;
        }
    }
}