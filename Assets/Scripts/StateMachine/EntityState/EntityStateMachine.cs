using Entities;
using Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace Scenes.EntityState2
{
    public abstract class EntityStateMachine : MonoBehaviour
    {
        public IEntityState currentState { get; protected set; }

        [SerializeField] protected EntityWrapper wrapper;

        public abstract void ChangeState(IEntityState newState);
    }
}