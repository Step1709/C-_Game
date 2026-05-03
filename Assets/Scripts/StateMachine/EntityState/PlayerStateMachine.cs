using Entities.MainPlayers;
using Scenes;
using TailMap;
using UI;
using UnityEngine;
using Screen = UI.Screen;

namespace Scenes.EntityState2
{
    public class PlayerStateMachine : StateMachine<PlayerStateMachine>
    {
        public MainPlayer player;
        
        public TileMovement TileGraph;
        
        public PlayerFightController fightController;
        
        public PlayerInterface Interface;
        
        void Start()
        {
            player = (MainPlayer)wrapper.Entity;
            Interface = Screen.Instance.PlayerInterface.GetComponent<PlayerInterface>();
        }

        public override void ToActiveState() => ChangeState(ActiveState.Instance);

        public override bool IsFinishedTurn => 
            currentState == WaitingState.Instance || currentState == DeathState.Instance;
    }
}