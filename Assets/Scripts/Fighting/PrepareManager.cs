using System.Collections;
using Scenes;
using UnityEngine;

namespace Fighting
{
    public class PrepareManager : MonoBehaviour
    {
        void OnEnable()
        {
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            Debug.Log("Wait 3 seconds");
            yield return new WaitForSeconds(3f);
            Debug.Log("Waited 3 seconds");
            StateMachine.Instance.ChangeState(FightState.Instance);
        }
    }
}