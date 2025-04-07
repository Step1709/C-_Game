using Scenes;
using UnityEngine;

public class BivMovementScript : MonoBehaviour
{
    public float moveSpeed = Biv.Instance.MoveSpeed;

    public Rigidbody2D rb;
    
    Vector2 movement;
    void Update()
    {
        if (GameModel.Instance.ChosenPlayer == Biv.Instance)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
