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

        void Update()
        {
            actionPoint.color = player.MainActionPoint == 1 ? Color.green : Color.red;
            movementText.text = player.CurrentTileCount + " / " + player.MaxTileCount;
        }
    }
}