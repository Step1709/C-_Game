using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerButtonsScript : MonoBehaviour
    {
        [SerializeField]
        private Image ashenHpBar;
        [SerializeField]
        private Image bivHpBar;
        
        [SerializeField]
        private TextMeshProUGUI ashenHpText;
        [SerializeField]
        private TextMeshProUGUI bivHpText;

        void FixedUpdate()
        {
            UpdateButton(Ashen.Instance, ashenHpBar, ashenHpText);
            UpdateButton(Biv.Instance, bivHpBar, bivHpText);
        }
        private void UpdateButton(MainPlayer player, Image bar, TextMeshProUGUI text)
        {
            bar.fillAmount = (float)player.Health / player.MaxHealth;
            text.text = player.Health + "/" + player.MaxHealth;
        }
        public void AshenButton()
        {
            GameModel.Instance.ChosenPlayer = Ashen.Instance;
        }
        
        public void BivButton()
        {
            GameModel.Instance.ChosenPlayer = Biv.Instance;
        }
    }
}