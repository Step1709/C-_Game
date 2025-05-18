using Fighting;
using Scenes;
using Scenes.EntityState2;

namespace Scenes
{
    public class FightState : IState
    {
        public static FightState Instance { get; } = new FightState();
        
        private FightManager fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();

        private ChangeChosen changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
        
        public void Enter()
        {
            changeChosen.enabled = false;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var stateMachine = player.GameObject.GetComponent<PlayerStateMachine>();
                stateMachine.ChangeState(WaitingState.Instance);
            }
            fightManager.enabled = true;
        }

        public void Exit()
        {
            fightManager.enabled = false;
        }
    }
}