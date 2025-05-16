using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Fighting
{
    public class FightManager : MonoBehaviour
    {
        private Wave currentWave;
        private List<GameObject> entities;
        private int currentEntityIndex;
        private EntityStateMachine stateMachine;
        private Entity entity;
        void OnEnable()
        {
            currentEntityIndex = 0;
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
            stateMachine = entities[currentEntityIndex].GetComponent<EntityStateMachine>();
            entity = entities[currentEntityIndex].GetComponent<EntityWrapper>().Entity;
            entity.UpdateStats();
            stateMachine.ChangeState(ActiveState.Instance);
            Debug.Log($"ход {entities[currentEntityIndex].name}");
        }

        void Update()
        {
            if (stateMachine.currentState == WaitingState.Instance)
            {
                currentEntityIndex = (currentEntityIndex + 1) % entities.Count;
                Debug.Log($"ход {entities[currentEntityIndex].name}");
                stateMachine = entities[currentEntityIndex].GetComponent<EntityStateMachine>();
                entity = entities[currentEntityIndex].GetComponent<EntityWrapper>().Entity;
                entity.UpdateStats();
                stateMachine.ChangeState(ActiveState.Instance);
            }
        }

        private GameObject InitEnemy(Enemy logic)
        {
            var enemy = Instantiate(logic.EntityPrefab, logic.StartPosition, Quaternion.identity);
            enemy.name = logic.Name;
            logic.GameObject = enemy;
            var wrapper = enemy.GetComponent<EntityWrapper>();
            wrapper.Entity = logic;
            var enemyAI = enemy.GetComponent<EnemyAI>();
            enemyAI.self = logic;
            var move = enemy.GetComponent<Move>();
            move.self = logic;
            var attack = enemy.GetComponent<Attack>();
            attack.self = logic;
            return enemy;
        }
    }
}