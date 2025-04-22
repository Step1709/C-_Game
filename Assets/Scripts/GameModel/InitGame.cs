using Entities;
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
            InitPlayer(AshenPrefab, new Vector2(0, 0), Ashen.Instance, "Ashen");
            InitPlayer(BivPrefab, new Vector2(5, 0), Biv.Instance, "Biv");
        }

        private void InitPlayer(GameObject prefab, Vector2 spawnPosition, MainPlayer logic, string name)
        {
            var player = Instantiate(prefab, spawnPosition, Quaternion.identity);
            player.name = name;
            var wrapper = player.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
        }
    }
}