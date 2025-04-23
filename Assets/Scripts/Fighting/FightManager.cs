using System.Collections.Generic;
using System.Linq;
using Entities;
using Scenes;
using UnityEngine;

namespace Fighting
{
    public class FightManager : MonoBehaviour
    {
        public Wave currentWave;
        public List<GameObject> entities;
        void OnEnable()
        {
            currentWave = GameModel.Instance.Waves.Dequeue();
            entities = GameModel.Instance.MainPlayers.ToList();
            foreach (var entity in currentWave.enemies)
            {
                entities.Add(InitEnemy(entity));
            }
        }

        private GameObject InitEnemy(Enemy logic)
        {
            var enemy = Instantiate(logic.EntityPrefab, logic.StartPosition, Quaternion.identity);
            enemy.name = logic.Name;
            var wrapper = enemy.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
            return enemy;
        }
    }
}