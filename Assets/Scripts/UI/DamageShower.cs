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
            var floatingText = Instantiate(floatingTextPrefab, 
                targetEntity.GameObject.transform.position + new Vector3(0,0.6f,0), Quaternion.identity);
            var text = floatingText.GetComponentInChildren<TextMeshPro>();
            text.text = damage;
            text.color = color;
            Destroy(floatingText, 1f);
        }
    }
}