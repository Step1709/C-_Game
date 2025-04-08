using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeCameraScript : MonoBehaviour
{
    public CameraClass Camera;

    void Start()
    {
        Camera = GameModel.Instance.SampleScene.Camera;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Camera.IsFree = !Camera.IsFree;
        }
    }
}
