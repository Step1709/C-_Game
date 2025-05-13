using Entities.MainPlayers;
using Scenes;
using TailMap;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class PlayerStateMachine : EntityStateMachine
    {
        public TileMovement TileGraph;
        
        public FinishMove finishMove;
        
        public PlayerBaseHandler baseHandler;
        
        public PathController pathController;
        
        public PlayerFightController fightController;
        
        public PlayerAction playerAction;
        void Awake()
        {
            currentState = PreparingState.Instance;
        }
        
        public override void ChangeState(IEntityState newState)
        {
            currentState?.Exit(this);
            newState?.Enter(this);
            currentState = newState;
        }
    }
}