using Scenes;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPos;
    private Vector3 offset;
    private float smoothSpeed;
    
    private float cameraSpeed;
    private Vector3 lastMousePosition;

    public void Start()
    {
        targetPos = GameModel.Instance.ChosenPlayer.Position;
        smoothSpeed = 0.125f;
        offset = new Vector3(0f, 0f, -10f);
        cameraSpeed = 0.05f;
    }

    public void Update()
    {
        if (!GameModel.Instance.SampleScene.Camera.IsFree)
        {
            targetPos = (Vector3)GameModel.Instance.ChosenPlayer.Position + offset;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var mouseDelta = Input.mousePosition - lastMousePosition;
                var deltaMove = -new Vector3(mouseDelta.x, mouseDelta.y, 0f) * cameraSpeed;
                targetPos += deltaMove;
                lastMousePosition = Input.mousePosition;
            }
        }
    }
    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
    
}