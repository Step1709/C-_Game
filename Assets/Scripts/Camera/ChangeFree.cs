using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeFree : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            CameraClass.Instance.IsFree = !CameraClass.Instance.IsFree;
        }
    }
}
