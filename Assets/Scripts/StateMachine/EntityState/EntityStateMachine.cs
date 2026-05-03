using Entities;
using Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace Scenes.EntityState2
{
    public abstract class EntityStateMachine : MonoBehaviour
    {
        [SerializeField] public EntityWrapper wrapper;
        public abstract bool IsFinishedTurn { get; }
        
        public abstract void ToActiveState();
    }

    public abstract class StateMachine<T> : EntityStateMachine where T :  StateMachine<T>
    {
        public IState<T> currentState { get; protected set; }

        public void ChangeState(IState<T> newState)
        {
            currentState?.Exit((T)this);
            newState?.Enter((T)this);
            currentState = newState;
        }
    }
}