using System.Collections;
using Scenes;
using UnityEngine;

namespace Fighting
{
    public class PrepareManager : MonoBehaviour
    {
        private int countdownTime = 10;
        void OnEnable()
        {
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            int timer = countdownTime;
            
            while(timer > 0)
            {
                if (UI.Screen.Instance.TimeCountText is not null)
                {
                    UI.Screen.Instance.TimeCountText.text = "Начало боя через: " + timer;
                }
                
                yield return new WaitForSeconds(1f);
                timer--;
            }
        
            StateMachine.Instance.ChangeState(FightState.Instance);
        }
    }
}