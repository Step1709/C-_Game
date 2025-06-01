using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fighting
{
    public class FightManager : MonoBehaviour
    {
        public List<Entity> entities;
        public int currentEntityIndex;
        public EntityStateMachine stateMachine;
        private Entity entity;
        void OnEnable()
        {
            GameModel.Instance.Enemies = GameModel.Instance.Waves.Dequeue();
            currentEntityIndex = 0;
            entities = GameModel.Instance.MainPlayers.Select(x=>(Entity)x).ToList();
            foreach (var entity in GameModel.Instance.Enemies)
            {
                entities.Add(entity);
                InitEnemy(entity);
            }
            entities = entities.OrderByDescending(entity => Random.Range(1,20)).ToList();
            Debug.Log("порядок ходов");
            foreach (var entity in entities)
            {
                Debug.Log(entity.Name);
            }
            stateMachine = entities[currentEntityIndex].GameObject.GetComponent<EntityStateMachine>();
            entity = entities[currentEntityIndex];
            entity.UpdateStats();
            stateMachine.ChangeState(ActiveState.Instance);
            Debug.Log($"ход {entities[currentEntityIndex].Name}");
        }

        void Update()
        {
            if (GameModel.Instance.MainPlayers.Count == 0) SceneManager.LoadScene("DeathScreen");
            else if (GameModel.Instance.Enemies.Count == 0)
            {
                if (GameModel.Instance.Waves.Count == 0) SceneManager.LoadScene("VictoryScreen");
                else StateMachine.Instance.ChangeState(PrepareState.Instance);
            }
            else if (stateMachine.currentState == WaitingState.Instance || stateMachine.currentState == DeathState.Instance)
            {
                currentEntityIndex = (currentEntityIndex + 1) % entities.Count;
                Debug.Log($"ход {entities[currentEntityIndex].Name}");
                stateMachine = entities[currentEntityIndex].GameObject.GetComponent<EntityStateMachine>();
                entity = entities[currentEntityIndex];
                entity.UpdateStats();
                stateMachine.ChangeState(ActiveState.Instance);
            }
        }

        private void InitEnemy(Enemy logic)
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
        }
    }
}