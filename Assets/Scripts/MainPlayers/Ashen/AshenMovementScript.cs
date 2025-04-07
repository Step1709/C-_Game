using Scenes;
using UnityEngine;

public class AshenMovementScript : MonoBehaviour
{
    public float moveSpeed = Ashen.Instance.MoveSpeed;

    public Rigidbody2D rb;
    
    Vector2 movement;
    void Update()
    {
        if (GameModel.Instance.ChosenPlayer == Ashen.Instance)
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
