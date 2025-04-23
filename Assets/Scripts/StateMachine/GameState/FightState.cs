using Fighting;
using Scenes.EntityState;

namespace Scenes
{
    public class FightState : IState
    {
        public static FightState Instance { get; } = new FightState();
        
        public FightManager fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
        public void Enter()
        {
            GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>().enabled = false;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                StateMachine.Instance.ChangeEntityState(player, WaitingState.Instance);
            }
            fightManager.enabled = true;
        }

        public void Exit()
        {
            fightManager.enabled = false;
        }
    }
}