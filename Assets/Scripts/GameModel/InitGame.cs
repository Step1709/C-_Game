using System.Collections.Generic;
using System.Linq;
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
            GameModel.Instance.OnPause = false;
            GameModel.Instance.Waves = new();
            GameModel.Instance.Waves.Enqueue(GameModel.Instance.Wave1[Random.Range(0, GameModel.Instance.Wave1.Count)]
                .Select(x=>x.Copy())
                .ToList());
            GameModel.Instance.Waves.Enqueue(GameModel.Instance.Wave2[Random.Range(0, GameModel.Instance.Wave2.Count)]
                .Select(x=>x.Copy())
                .ToList());
            GameModel.Instance.GameModelObject = GameObject.Find("GameModel");
            GameModel.Instance.Floor =  GameObject.Find("Floor").GetComponent<Tilemap>();
            GameModel.Instance.Walls = GameObject.Find("Walls").GetComponent<Tilemap>();
            GameModel.Instance.HighlightTilemap = GameObject.Find("HighlightTilemap").GetComponent<Tilemap>();
            GameModel.Instance.MainPlayers = new List<MainPlayer>() {Ashen.Instance, Biv.Instance, Brightfire.Instance};
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                InitPlayer(player);
                player.Update();
            }
            GameModel.Instance.ChosenPlayer = Ashen.Instance;
            CameraClass.Instance.IsFree = false;
            CameraClass.Instance.ChosenEntity = GameModel.Instance.ChosenPlayer.GameObject;
            UI.Screen.Instance.Init();
            StateMachine.Instance.ChangeState(PrepareState.Instance);
        }

        private void InitPlayer(MainPlayer logic)
        {
            var player = Instantiate(logic.EntityPrefab, logic.StartPosition, Quaternion.identity);
            player.name = logic.Name;
            var wrapper = player.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
            var move = player.GetComponent<Move>();
            move.self = logic;
            var attack = player.GetComponent<Attack>();
            attack.self = logic;
            logic.GameObject = player;
        }
    }
}