using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeFree : MonoBehaviour
{
    public CameraClass Camera;

    public ChangeFree(CameraClass camera)
    {
        Camera = camera;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Camera.IsFree = !Camera.IsFree;
        }
    }
}
