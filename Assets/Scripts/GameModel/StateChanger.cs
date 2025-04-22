using UnityEngine;

namespace Scenes
{
    public class StateChanger : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StateMachine.Instance.ChangeState(PrepareState.Instance);
            }

            else if (Input.GetKeyDown(KeyCode.X))
            {
                StateMachine.Instance.ChangeState(FightState.Instance);
            }
        }
    }
}