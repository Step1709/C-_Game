using System.Collections.Generic;
using Fighting;
using Scenes;
using Scenes.EntityState2;
using TMPro;
using UnityEngine;

namespace Training
{
    public class UseAbilityInstruction : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI instruction;

        private FightManager fightManager;
        
        [SerializeField] private FinishTurnInstruction finishTurnInstruction;
        void OnEnable()
        {
            fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            instruction.text = "Выберите на панели снизу способность и нажмите ЛКМ чтобы использовать ее";
        }
        
        void Update()
        {
            if (fightManager.stateMachine.currentState == UsingAbilityState.Instance &&
                fightManager.stateMachine.CompareTag("Player"))
            {
                enabled = false;
                finishTurnInstruction.enabled = true;
            }
        }
    }
}