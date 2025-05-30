using System;
using TMPro;
using UnityEngine;

namespace Training
{
    public class CameraTest : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI instText;
        [SerializeField] private FightInstructions fightInst;
        
        private int QCounter;
        void OnEnable()
        {
            QCounter = 0;
            instText.text = "Перейдите в режим свободной камеры и осмотрите карту";
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QCounter++;
                if (QCounter == 1) instText.text = "Используйте Q чтобы выйти из режима свободной камеры";
                else if (QCounter == 2)
                {
                    instText.text = "";
                    enabled = false;
                    fightInst.enabled = true;
                }
            }
        }
    }
}