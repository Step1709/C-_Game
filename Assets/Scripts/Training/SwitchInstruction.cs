using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Training
{
    public class SwitchInstruction : MonoBehaviour
    {
        public Queue<string> Instructions;
        
        [SerializeField] private GameObject instructions;
        [SerializeField] private TextMeshProUGUI instructionsText;

        void OnEnable()
        {
            instructions.SetActive(true);
            instructionsText.text = Instructions.Dequeue();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Instructions.Count == 0)
                {
                    enabled = false;
                    instructions.SetActive(false);
                    instructionsText.text = "";
                }
                else instructionsText.text = Instructions.Dequeue();
            }
        }
    }
}