using System.Collections.Generic;
using UnityEngine;

namespace Training
{
    public class CameraInstructions : MonoBehaviour
    {
        [SerializeField] private SwitchInstruction switchInstruction;
        
        [SerializeField] private CameraTest cameraTest;
        void OnEnable()
        {
            var instructions = new Queue<string>();
            instructions.Enqueue("Добро пожаловать в обучение игры! Это пошаговая стратегия, в которой главную роль играет тактика и позиционирование ваших бойцов на арене");
            instructions.Enqueue("Чтобы перевести камеру в свободный режим используйте Q. Управляйте камерой при помощи клавиш W,A,S,D. Приближайте и отдаляйте камеру при помощи колесика мыши");
            switchInstruction.Instructions = instructions;
            switchInstruction.enabled = true;
        }

        void Update()
        {
            if (!switchInstruction.enabled)
            {
                enabled = false;
                cameraTest.enabled = true;
            }
        }
    }
}