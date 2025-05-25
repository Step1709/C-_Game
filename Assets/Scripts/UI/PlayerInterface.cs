using Abilities;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerInterface : MonoBehaviour
    {
        public MainPlayer player;

        [SerializeField] private Image actionPoint;
        
        [SerializeField] private TextMeshProUGUI movementText;
        
        [SerializeField] private Image slotImage1;
        [SerializeField] private Image slotImage2;
        [SerializeField] private Image slotImage3;
        
        [SerializeField] public Image abilityImage1;
        [SerializeField] public Image abilityImage2;
        [SerializeField] public Image abilityImage3;

        private Image[] slots;
        void Awake()
        {
            slots = new[] {slotImage1, slotImage2, slotImage3};
        }
        void FixedUpdate()
        {
            actionPoint.color = player.MainActionPoint == 1 ? Color.green : Color.red;
            movementText.text = player.CurrentTileCount + " / " + player.MaxTileCount;
            for (var i = 0; i<slots.Length; i++)
            {
                slots[i].color = i==player.AbilityIndex ? Color.black : Color.grey;
            }
        }

        public void UpdateAbilityImages()
        {
            abilityImage1.sprite = ((IPlayerAbility)player.Abilities[0]).Image;
            abilityImage2.sprite = ((IPlayerAbility)player.Abilities[1]).Image;
            abilityImage3.sprite = ((IPlayerAbility)player.Abilities[2]).Image;
        }
    }
}