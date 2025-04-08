using UnityEngine;

namespace Scenes
{
    public class PlayerBaseHandler : MonoBehaviour
    {
        private MainPlayer mainPlayer; 
        
        public Rigidbody2D rb;
    
        private Vector2 movement;

        public PlayerBaseHandler(MainPlayer mainPlayer)
        {
            this.mainPlayer = mainPlayer;
        }

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            mainPlayer.Position = rb.position;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        
        public void FixedUpdate()
        {
            if (mainPlayer == GameModel.Instance.ChosenPlayer)
            {
                rb.MovePosition(rb.position + mainPlayer.MoveSpeed * Time.fixedDeltaTime * movement);
            }
        }
    }
}