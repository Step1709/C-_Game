using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using Entities.MainPlayers;
using Scenes;
using Scenes.Scene;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Training
{
    public class TrainingInit : MonoBehaviour
    {
        void Awake()
        {
            GameModel.Instance.OnPause = false;
            GameModel.Instance.Waves = new();
            GameModel.Instance.Waves.Enqueue(new List<Enemy> {new Warrior(new Vector2(10,10), "Warrior"), new Magic(new Vector2(20,10), "Wizard")});
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
            var camInst = GameObject.Find("TrainingManager").GetComponent<CameraInstructions>();
            camInst.enabled = true;
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