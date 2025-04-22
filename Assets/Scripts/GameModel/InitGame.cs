using Entities;
using Scenes.Scene;
using TailMap;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Scenes
{
    public class InitGame : MonoBehaviour
    {
        public GameObject AshenPrefab;
        public GameObject BivPrefab;
        void Start()
        {
            Ashen.Instance.PlayerObject = InitPlayer(AshenPrefab, new Vector2(0, 0), Ashen.Instance, "Ashen");
            Biv.Instance.PlayerObject = InitPlayer(BivPrefab, new Vector2(5, 0), Biv.Instance, "Biv");
            GameModel.Instance.ChosenPlayer = Ashen.Instance.PlayerObject;
            CameraClass.Instance.ChosenEntity = GameModel.Instance.ChosenPlayer;
        }

        private GameObject InitPlayer(GameObject prefab, Vector2 spawnPosition, MainPlayer logic, string name)
        {
            var player = Instantiate(prefab, spawnPosition, Quaternion.identity);
            player.name = name;
            var wrapper = player.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
            GameModel.Instance.MainPlayers.Add(player);
            return player;
        }
    }
}