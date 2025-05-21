using UnityEngine;
using UnityEngine.UI;
namespace UI
{
    public class Screen
    {
        public static Screen Instance { get; } = new Screen();

        public GameObject PlayerButtons;
        
        public Button AshenButton;
        
        public Button BivButton;
        
        public void Init()
        {
            PlayerButtons = GameObject.Find("PlayerButtons");
            AshenButton = PlayerButtons.transform.Find("AshenButton").GetComponent<Button>();
            BivButton = PlayerButtons.transform.Find("BivButton").GetComponent<Button>();
            PlayerButtons.SetActive(false);
        }
    }
}