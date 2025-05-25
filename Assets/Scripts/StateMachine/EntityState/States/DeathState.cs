using System.Linq;
using Fighting;
using Scenes.Scene;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class DeathState :  IPlayerState, IEnemyState
    {
        public static DeathState Instance { get; } = new DeathState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.player.ChangeButton(false);
            GameModel.Instance.MainPlayers.Remove(stateMachine.player);
            var fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            if (fightManager.entities.IndexOf(stateMachine.player) <= fightManager.currentEntityIndex)
                fightManager.currentEntityIndex --;
            fightManager.entities.Remove(stateMachine.player);
            GameModel.Instance.ChosenPlayer = GameModel.Instance.MainPlayers.FirstOrDefault();
            GameObject.Destroy(stateMachine.gameObject);
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
            GameModel.Instance.Enemies.Remove(stateMachine.enemy);
            var fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            if (fightManager.entities.IndexOf(stateMachine.enemy) <= fightManager.currentEntityIndex)
                fightManager.currentEntityIndex --;
            fightManager.entities.Remove(stateMachine.enemy);
            GameObject.Destroy(stateMachine.gameObject);
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
            
        }
    }
}