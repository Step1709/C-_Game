using System.Collections.Generic;
using System.Linq;
using Entities;
using Scenes;
using Scenes.EntityState;
using UnityEngine;

namespace Fighting
{
    public class FightManager : MonoBehaviour
    {
        private Wave currentWave;
        private List<GameObject> entities;
        private int currentEntityIndex = 0;
        private Entity entity;
        void OnEnable()
        {
            currentWave = GameModel.Instance.Waves.Dequeue();
            entities = GameModel.Instance.MainPlayers.ToList();
            foreach (var entity in currentWave.enemies)
            {
                entities.Add(InitEnemy(entity));
            }
            entities = entities.OrderByDescending(entity => Random.Range(1,20)).ToList();
            Debug.Log("порядок ходов");
            foreach (var entity in entities)
            {
                Debug.Log(entity.name);
            }
            entity = entities[currentEntityIndex].GetComponent<EntityWrapper>().Entity;
            StateMachine.Instance.ChangeEntityState(entities[currentEntityIndex], ActiveState.Instance);
            Debug.Log("ход следующего");
        }

        void Update()
        {
            if (entity.currentState == WaitingState.Instance)
            {
                currentEntityIndex = (currentEntityIndex + 1) % entities.Count;
                Debug.Log("ход следующего");
                StateMachine.Instance.ChangeEntityState(entities[currentEntityIndex], ActiveState.Instance);
                entity = entities[currentEntityIndex].GetComponent<EntityWrapper>().Entity;
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