using Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class EntityStateMachine : MonoBehaviour
    {
        public IEntityState currentState { get; protected set; }

        public virtual void ChangeState(IEntityState newState)
        {
            
        }
    }
}