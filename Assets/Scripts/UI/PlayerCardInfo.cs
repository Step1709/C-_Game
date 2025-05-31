using Scenes;
using UnityEngine;

namespace UI
{
    public class PlayerCardInfo : MonoBehaviour
    {
        [SerializeField] private PlayerInterface playerInterface;
        private MainPlayer player;

        void OnEnable()
        {
            player = playerInterface.player;
            Debug.Log(player);
        }
    }
}