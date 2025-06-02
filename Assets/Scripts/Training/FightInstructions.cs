using System.Collections.Generic;
using Scenes;
using UnityEngine;

namespace Training
{
    public class FightInstructions : MonoBehaviour
    {
        [SerializeField] private SwitchInstruction switchInstruction;
        
        [SerializeField] private PrepareInstruction prepareInstruction;

        void OnEnable()
        {
            var instructions = new Queue<string>();
            instructions.Enqueue("Теперь пришло время знакомиться с бойцами");
            instructions.Enqueue("Ashen - боевой маг. Силен в дальнем бою и терпеть не может ближних столкновений");
            instructions.Enqueue("Biv, напротив, как истинный рыцарь считает что магия для слабаков и что истинный воин должен орудовать мечами, топорами и кулаками. Чтобы сокрушать врагов использует только ближние атаки");
            instructions.Enqueue("Bright - целитель. Без него наша команда не пережила бы и первой своей битвы. Пацифист и поэтому орудует только целительными заклинаниями");
            instructions.Enqueue("За один ход каждый герой может использовать ровно одну из трех своих способностей и использовать некоторое количество очков перемещения");
            instructions.Enqueue("Чтобы пережить столкновение важно грамотно к нему подготовиться : если в начале боя бойцы будут расположены как попало, враги быстро их окружат и уничтожат");
            instructions.Enqueue("Во время подготовки к бою вы можете свободно перемещать своих бойцов по карте. Чтобы выбрать бойца, нажмите на его иконку слева. На иконке также содержится информация о здоровье бойца");
            instructions.Enqueue("Чтобы переместить бойца в нужную точку, укажите ее на карте при помощи ЛКМ и боец сам до нее дойдет");
            switchInstruction.Instructions = instructions;
            switchInstruction.enabled = true;
        }

        void Update()
        {
            if (!switchInstruction.enabled)
            {
                enabled = false;
                prepareInstruction.enabled = true;
            }
        }
    }
}