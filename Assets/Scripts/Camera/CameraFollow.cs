using Scenes;
using Scenes.Scene;
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
        smoothSpeed = 0.125f;
        offset = new Vector3(0f, 0f, -10f);
        cameraSpeed = 10f;
    }

    public void Update()
    {
        if (!CameraClass.Instance.IsFree && CameraClass.Instance.ChosenEntity is not null)
        {
            targetPos = CameraClass.Instance.ChosenEntity.transform.position + offset;
        }
        else
        {
            var deltaMove = cameraSpeed * Time.deltaTime * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") , 0f);
            targetPos += deltaMove;
        }
    }
    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
    
}