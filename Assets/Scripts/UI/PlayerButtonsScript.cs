using Scenes;
using UnityEngine;

namespace UI
{
    public class PlayerButtonsScript : MonoBehaviour
    {
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