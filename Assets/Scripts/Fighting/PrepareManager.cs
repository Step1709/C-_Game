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
            Debug.Log("Wait 5 seconds");
            yield return new WaitForSeconds(5f);
            Debug.Log("Waited 5 seconds");
            StateMachine.Instance.ChangeState(FightState.Instance);
        }
    }
}