using Entities;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DamageShower : MonoBehaviour
    {
        [SerializeField] private GameObject floatingTextPrefab;
        
        public void ShowDamage(Entity targetEntity, string damage, Color color)
        {
            var floatingText = Instantiate(floatingTextPrefab, targetEntity.GameObject.transform.position, Quaternion.identity);
            var text = floatingText.GetComponentInChildren<TextMeshPro>();
            text.text = damage;
            text.color = color;
            Destroy(floatingText, 1f);
        }
    }
}