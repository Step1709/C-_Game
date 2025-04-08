using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public CameraClass Camera;

    public Camera camera;
    private float size;
    private float smoothSpeed = 10f;
    private float zoomSensitivity = 5f;
    private  float maxZoom = 10f;
    private float minZoom = 2f;

    public ChangeSize(CameraClass camera)
    {
        Camera = camera;
    }
    void Start()
    {
        camera = GetComponent<Camera>();
        size = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.IsFree) maxZoom = 15f;
        else maxZoom = 10f;
        float scrollAmount = Input.GetAxis("Mouse ScrollWheel");
        size += scrollAmount * zoomSensitivity;
        if (size >= maxZoom) size = maxZoom;
        else if (size <= minZoom) size = minZoom;
    }

    void FixedUpdate()
    {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, Time.deltaTime * smoothSpeed);
    }
}
