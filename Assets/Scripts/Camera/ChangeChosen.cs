using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeChosen : MonoBehaviour
{
    public CameraClass Camera;

    public ChangeChosen(CameraClass camera)
    {
        Camera = camera;
    }
    void Update()
    {
        Camera.ChosenEntity = GameModel.Instance.ChosenPlayer;
    }
}
