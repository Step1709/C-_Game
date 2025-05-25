using Entities;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TargetInfo : MonoBehaviour
    {
        public Entity targetEntity;
        
        [SerializeField]
        private Image bar;
        
        [SerializeField]
        private TextMeshProUGUI textHp;
        
        [SerializeField]
        private TextMeshProUGUI textName;
        
        void FixedUpdate()
        {
            bar.fillAmount = (float)targetEntity.Health / targetEntity.MaxHealth;
            textHp.text = targetEntity.Health + "/" + targetEntity.MaxHealth;
            textName.text = targetEntity.Name;
        }
    }
}