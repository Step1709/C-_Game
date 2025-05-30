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
        void OnEnable()
        {
            fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
            instruction.text = "Нажмите пробел чтобы завершить ход";
        }
        
        void Update()
        {
            if (fightManager.currentEntityIndex!=0) enabled = false;
        }

        void OnDisable()
        {
            instruction.text = "Победите врагов";
        }
    }
}