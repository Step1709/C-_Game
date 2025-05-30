using System.Collections.Generic;
using Scenes;
using UnityEngine;

namespace Training
{
    public class FightInstructions : MonoBehaviour
    {
        [SerializeField] private SwitchInstruction switchInstruction;

        void OnEnable()
        {
            var instructions = new Queue<string>();
            instructions.Enqueue("Теперь пришло время знакомиться с бойцами");
            instructions.Enqueue("Ashen - боевой маг. Силен в дальнем бою и терпеть не может ближних столкновений");
            instructions.Enqueue("Biv, напротив, как истинный варвар считает что магия для слабаков и что истинный воин должен орудовать мечами и топорами. Чтобы сокрушать врагов использует только ближние атаки");
            instructions.Enqueue("Bright - целитель. Без него наша команда не пережила бы и первой своей битвы. Пацифист и поэтому орудует только целительными заклинаниями");
            instructions.Enqueue("За один ход каждый герой может один использовать одну из трех своих способностей и сделать определенное количество шагов");
            switchInstruction.Instructions = instructions;
            switchInstruction.enabled = true;
        }

        void Update()
        {
            if (!switchInstruction.enabled)
            {
                enabled = false;
            }
        }

        void OnDisable()
        {
            StateMachine.Instance.ChangeState(FightState.Instance);
        }
    }
}