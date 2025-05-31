using Fighting;
using Scenes;
using Scenes.EntityState2;
using TMPro;
using UnityEngine;

namespace Training
{
    public class FinishTurnInstruction : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI instruction;

        private FightManager fightManager;

        private PlayerStateMachine stateMachine;
        void OnEnable()
        {
            fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            stateMachine = (PlayerStateMachine)fightManager.stateMachine;
            instruction.text = "Нажмите SPACE чтобы завершить ход";
        }
        
        void Update()
        {
            if (stateMachine.currentState == WaitingState.Instance)
            {
                enabled = false;
                instruction.text = "Победите врагов";
            }
        }
    }
}