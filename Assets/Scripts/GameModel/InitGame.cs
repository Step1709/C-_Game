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
            Ashen.Instance.PlayerObject = InitPlayer(Ashen.Instance);
            Biv.Instance.PlayerObject = InitPlayer(Biv.Instance);
            GameModel.Instance.ChosenPlayer = Ashen.Instance.PlayerObject;
            CameraClass.Instance.ChosenEntity = GameModel.Instance.ChosenPlayer;
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
            var playerAction = player.GetComponent<PlayerAction>();
            playerAction.self = logic;
            var playerFightController = player.GetComponent<PlayerFightController>();
            playerFightController.player = logic;
            GameModel.Instance.MainPlayers.Add(player);
            return player;
        }
    }
}