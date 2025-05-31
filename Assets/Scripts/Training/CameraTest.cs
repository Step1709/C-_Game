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
            instText.text = "Перейдите в режим свободной камеры(Q).";
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QCounter++;
                if (QCounter == 1) instText.text = "Осмотрите карту(W,A,S,D). Изменяйте размеры камеры колесиком мыши. Чтобы продолжить, выйдите из режима свободной камеры(Q)";
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