using Entities;
using Scenes;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class AbilityInfo : MonoBehaviour
    {
        private Vector2 mousePos;
        
        public PathController pathController;
        
        private TargetController targetController;
        
        [SerializeField] private TextMeshProUGUI tileCount;
        
        [SerializeField] private TextMeshProUGUI chance;
        
        [SerializeField] private TextMeshProUGUI damage;

        void Start()
        {
            targetController = GameModel.Instance.GameModelObject.GetComponent<TargetController>();
        }
        void Update()
        {
            mousePos = Input.mousePosition;
        }

        void FixedUpdate()
        {
            tileCount.text = pathController.path is null ? "" : pathController.path.Count.ToString();
            if (pathController.target is null)
            {
                chance.text = "";
                damage.text = "";
            }
            else
            {
                var weapon = (Weapon)pathController.player.currentAbility;
                var minDamage = weapon.minDamage;
                var maxDamage = weapon.maxDamage;
                damage.text = minDamage + "-" + maxDamage;
                if (weapon is HealWeapon) chance.text = "100%";
                else if (weapon is DamageWeapon)
                    chance.text = (20 - targetController.targetEntity.ArmorClass) * 5 + "%";
            }
            transform.position = mousePos;
        }
    }
}