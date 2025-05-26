using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeFree : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraClass.Instance.IsFree = !CameraClass.Instance.IsFree;
        }
    }
}
