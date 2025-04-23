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
        void Start()
        {
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
            GameModel.Instance.MainPlayers.Add(player);
            return player;
        }
    }
}