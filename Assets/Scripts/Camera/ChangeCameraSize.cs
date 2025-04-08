using UnityEngine;

public class ChangeCameraSize : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera camera;
    private float size;
    private float smoothSpeed = 10f;
    private float zoomSensitivity = 5f;
    private  float maxZoom = 10f;
    private float minZoom = 2f;
    void Start()
    {
        camera = GetComponent<Camera>();
        size = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
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
