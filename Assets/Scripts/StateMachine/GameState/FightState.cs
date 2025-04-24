using Fighting;
using Scenes.EntityState;

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