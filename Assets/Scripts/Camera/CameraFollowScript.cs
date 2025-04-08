using Scenes;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isFreeCamera;
    private MainPlayer target;
    private Vector3 offset;
    private Vector3 SmoothedPosition;
    private float smoothSpeed;

    public void Start()
    {
        target = GameModel.Instance.ChosenPlayer;
        smoothSpeed = 0.125f;
        offset = new Vector3(0f, 0f, -10f);
        isFreeCamera = false;
    }

    public void Update()
    {
        target = GameModel.Instance.ChosenPlayer;
        
        var desiredPosition = (Vector3)target.Position + offset;
        
        SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
    public void FixedUpdate()
    {
        transform.position = SmoothedPosition;
    }
    
}