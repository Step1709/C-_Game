using Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class EntityStateMachine : MonoBehaviour
    {
        public FinishMove finishMove;
        
        public IEntityState currentState;

        public virtual void ChangeState(IEntityState newState)
        {
            
        }
    }
}