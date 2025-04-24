using Entities;
using Scenes.EntityState;
using UnityEngine;

namespace Scenes
{
    public class FinishMove : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StateMachine.Instance.ChangeEntityState(gameObject, WaitingState.Instance);
            }
        }
    }
}