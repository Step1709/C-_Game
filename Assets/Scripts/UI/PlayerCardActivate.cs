using UnityEngine;

namespace UI
{
    public class PlayerCardActivate : MonoBehaviour
    {
        [SerializeField] private GameObject card;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                card.SetActive(true);
            }
            else if (!Input.GetKey(KeyCode.Tab))
            {
                card.SetActive(false);
            }
        }
    }
}