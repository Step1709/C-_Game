using Scenes;
using TMPro;
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
        
        public Button BrightButton;

        public TextMeshProUGUI TimeCountText;

        public GameObject TargetInfo;

        public GameObject PlayerInterface;
        
        public GameObject AbilityInfo;
        
        public GameObject TargetAbilityInfo;
        
        public DamageShower DamageShower;
        
        public void Init()
        {
            DamageShower = GameModel.Instance.GameModelObject.GetComponent<DamageShower>();
            PlayerInterface = GameObject.Find("PlayerInterface");
            PlayerInterface.SetActive(false);
            AbilityInfo = GameObject.Find("AbilityInfo");
            AbilityInfo.SetActive(false);
            PlayerButtons = GameObject.Find("PlayerButtons");
            AshenButton = PlayerButtons.transform.Find("AshenButton").GetComponent<Button>();
            BivButton = PlayerButtons.transform.Find("BivButton").GetComponent<Button>();
            BrightButton = PlayerButtons.transform.Find("BrightfireButton").GetComponent<Button>();
            TimeCountText = GameObject.Find("TimeCountText").GetComponent<TextMeshProUGUI>();
            TargetInfo = GameObject.Find("TargetInfo");
            TargetAbilityInfo = TargetInfo.transform.Find("TargetAbilityInfo").gameObject;
            TargetInfo.SetActive(false);
        }
    }
}