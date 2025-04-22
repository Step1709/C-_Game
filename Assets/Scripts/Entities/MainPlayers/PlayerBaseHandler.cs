using Entities;
using UnityEngine;

namespace Scenes
{
    public class PlayerBaseHandler : MonoBehaviour
    {
        public MainPlayer mainPlayer; 
        
        public Rigidbody2D rb;
    
        private Vector2 movement;
        

        public void Start()
        {
            mainPlayer  = (MainPlayer)GetComponent<EntityWrapper>().Entity;
        }

        public void Update()
        {
            if (mainPlayer == GameModel.Instance.ChosenPlayer)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }
        }
        
        public void FixedUpdate()
        {
            
            if (mainPlayer == GameModel.Instance.ChosenPlayer)
            {
                rb.MovePosition(rb.position + mainPlayer.MoveSpeed * Time.fixedDeltaTime * movement.normalized);
            }
        }
    }
}