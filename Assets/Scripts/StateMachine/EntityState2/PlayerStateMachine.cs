using Scenes.EntityState;
using TailMap;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class PlayerStateMachine : EntityStateMachine
    {
        public TailGraph TileGraph;
        
        public PlayerBaseHandler baseHandler;

        public override void ChangeState(IEntityState newState)
        {
            currentState.Exit(this);
            newState.Enter(this);
            currentState = newState;
        }
    }
}