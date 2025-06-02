using Abilities;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerCardInfo : MonoBehaviour
    {
        [SerializeField] private PlayerInterface playerInterface;
        private MainPlayer player;
        
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private Image playerIcon;
        
        [SerializeField] private TextMeshProUGUI ability1Name;
        [SerializeField] private TextMeshProUGUI ability1Description;
        [SerializeField] private Image ability1Icon;
        
        [SerializeField] private TextMeshProUGUI ability2Name;
        [SerializeField] private TextMeshProUGUI ability2Description;
        [SerializeField] private Image ability2Icon;
        
        [SerializeField] private TextMeshProUGUI ability3Name;
        [SerializeField] private TextMeshProUGUI ability3Description;
        [SerializeField] private Image ability3Icon;
        
        [SerializeField] private TextMeshProUGUI ability4Name;
        [SerializeField] private TextMeshProUGUI ability4Description;
        [SerializeField] private Image ability4Icon;

        void OnEnable()
        {
            player = playerInterface.player;
            playerName.text = player.Name;

            playerIcon.sprite = player.Icon;
            
            ability1Name.text = ((IPlayerAbility)player.Abilities[0]).Name;
            ability1Description.text = ((IPlayerAbility)player.Abilities[0]).Description;
            ability1Icon.sprite = ((IPlayerAbility)player.Abilities[0]).Icon;
            
            ability2Name.text = ((IPlayerAbility)player.Abilities[1]).Name;
            ability2Description.text = ((IPlayerAbility)player.Abilities[1]).Description;
            ability2Icon.sprite = ((IPlayerAbility)player.Abilities[1]).Icon;
            
            ability3Name.text = ((IPlayerAbility)player.Abilities[2]).Name;
            ability3Description.text = ((IPlayerAbility)player.Abilities[2]).Description;
            ability3Icon.sprite = ((IPlayerAbility)player.Abilities[2]).Icon;
            
            ability4Name.text = ((IPlayerAbility)player.Abilities[3]).Name;
            ability4Description.text = ((IPlayerAbility)player.Abilities[3]).Description;
            ability4Icon.sprite = ((IPlayerAbility)player.Abilities[3]).Icon;
        }
    }
}