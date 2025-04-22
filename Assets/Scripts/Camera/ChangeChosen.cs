using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeChosen : MonoBehaviour
{
    void Update()
    {
        CameraClass.Instance.ChosenEntity = GameModel.Instance.ChosenPlayer;
    }
}
