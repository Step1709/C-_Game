using Fighting;
using Scenes;
using Scenes.EntityState2;
using TMPro;
using UnityEngine;

namespace Training
{
    public class PrepareInstruction : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI instText;
        
        [SerializeField] private UseAbilityInstruction useAbilityInstruction;

        void OnEnable()
        {
            instText.text = "Подготовьте своих бойцов к битве. Нажмите ENTER чтобы начать бой";
            var changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
            changeChosen.enabled = true;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var stateMachine = player.GameObject.GetComponent<PlayerStateMachine>();
                player.ChangeButton(true);
                stateMachine.ChangeState(PreparingState.Instance);
            }
            UI.Screen.Instance.PlayerInterface.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) enabled = false;
        }

        void OnDisable()
        {
            var changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
            changeChosen.enabled = false;
            StateMachine.Instance.ChangeState(FightState.Instance);
            useAbilityInstruction.enabled = true;
        }
    }
}