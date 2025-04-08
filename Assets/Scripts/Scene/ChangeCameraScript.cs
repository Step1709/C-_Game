using Scenes.Scene;
using UnityEngine;

public class ChangeCameraScript : MonoBehaviour
{
    public CameraClass Camera;
    public ChangeCameraScript(SceneClass scene)
    {
        Camera = scene.Camera;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Camera.IsFree = !Camera.IsFree;
        }
    }
}
