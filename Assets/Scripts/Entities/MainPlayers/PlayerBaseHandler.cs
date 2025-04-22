using Entities;
using UnityEngine;

namespace Scenes
{
    public class PlayerBaseHandler : MonoBehaviour
    {
        private MainPlayer mainPlayer;
        
        public Rigidbody2D rb;
    
        private Vector2 movement;

        void Start()
        {
            mainPlayer = (MainPlayer)GetComponent<EntityWrapper>().Entity;
        }
        public void Update()
        {
            if (gameObject == GameModel.Instance.ChosenPlayer)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }
        }
        
        public void FixedUpdate()
        {
            
            if (gameObject == GameModel.Instance.ChosenPlayer)
            {
                rb.MovePosition(rb.position + mainPlayer.MoveSpeed 
                    * Time.fixedDeltaTime * movement.normalized);
            }
        }
    }
}