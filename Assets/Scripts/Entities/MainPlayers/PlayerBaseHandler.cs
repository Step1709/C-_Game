using Entities;
using UnityEngine;

namespace Scenes
{
    public class PlayerBaseHandler : MonoBehaviour
    {
        public MainPlayer mainPlayer;
        
        public Rigidbody2D rb;
    
        private Vector2 movement;
        
        [SerializeField]
        private EntityWrapper wrapper;

        private void Start()
        {
            mainPlayer = (MainPlayer)wrapper.Entity;
        }
        public void Update()
        {
            if (gameObject == GameModel.Instance.ChosenPlayer.GameObject)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }
        }
        
        public void FixedUpdate()
        {
            
            if (gameObject == GameModel.Instance.ChosenPlayer.GameObject)
            {
                rb.MovePosition(rb.position + mainPlayer.MoveSpeed 
                    * Time.fixedDeltaTime * movement.normalized);
            }
        }
    }
}