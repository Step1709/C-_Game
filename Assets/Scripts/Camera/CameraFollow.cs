using Scenes;
using Scenes.Scene;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraClass Camera;
        
    private Vector3 targetPos;
    private Vector3 offset;
    private float smoothSpeed;
    
    private float cameraSpeed;
    private Vector3 lastMousePosition;

    public CameraController(CameraClass camera)
    {
        Camera = camera;
    }

    public void Start()
    {
        targetPos = Camera.ChosenEntity.Position;
        smoothSpeed = 0.125f;
        offset = new Vector3(0f, 0f, -10f);
        cameraSpeed = 0.05f;
    }

    public void Update()
    {
        if (!Camera.IsFree)
        {
            targetPos = (Vector3)Camera.ChosenEntity.Position + offset;
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