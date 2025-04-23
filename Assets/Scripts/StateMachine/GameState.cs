using Entities;
using Scenes.EntityState;
using UnityEngine;

namespace Scenes
{
    public class StateMachine
    {
        public static StateMachine Instance { get; }= new StateMachine();
        
        private IState currentState = PrepareState.Instance;

        public void ChangeState(IState newState)
        {
            currentState.Exit();
            newState.Enter();
            currentState = newState;
        }

        public void ChangeEntityState(GameObject entityObj, IEntityState newState)
        {
            var entity = entityObj.GetComponent<EntityWrapper>().Entity;
            entity.currentState.Exit(entityObj);
            newState.Enter(entityObj);
            entity.currentState = newState;
        }
    }
}