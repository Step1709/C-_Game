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
        [SerializeField] private ChangeFree changeFree;

        void OnEnable()
        {
            changeFree.enabled = false;
            instructions.SetActive(true);
            instructionsText.text = Instructions.Dequeue();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Instructions.Count == 0)
                {
                    changeFree.enabled = true;
                    enabled = false;
                    instructions.SetActive(false);
                    instructionsText.text = "";
                }
                else instructionsText.text = Instructions.Dequeue();
            }
        }
    }
}