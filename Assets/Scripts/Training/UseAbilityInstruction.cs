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
            instruction.text = "Изучите способности управляемого вами бойца(Tab). Выберите на панели снизу любую способность и используйте ее(ЛКМ)";
        }
        
        void Update()
        {
            if (!fightManager.stateMachine.CompareTag("Player") ||
                ((PlayerStateMachine)fightManager.stateMachine).currentState != UsingAbilityState.Instance) return;
            enabled = false;
            finishTurnInstruction.enabled = true;
        }
    }
}