using Scenes.EntityState2;
using UnityEngine;

namespace Scenes
{
    public class FinishMove : MonoBehaviour
    {
        public EntityStateMachine stateMachine;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(WaitingState.Instance);
            }
        }
    }
}