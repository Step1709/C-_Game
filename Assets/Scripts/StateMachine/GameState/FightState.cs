using Fighting;
using Scenes;
using Scenes.EntityState2;

namespace Scenes
{
    public class FightState : IState
    {
        public static FightState Instance { get; } = new FightState();
        
        public void Enter()
        {
            var fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            var changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
            changeChosen.enabled = false;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var stateMachine = player.GameObject.GetComponent<PlayerStateMachine>();
                player.ChangeButton(false);
                stateMachine.ChangeState(WaitingState.Instance);
            }
            fightManager.enabled = true;
        }

        public void Exit()
        {
            var fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            fightManager.enabled = false;
        }
    }
}