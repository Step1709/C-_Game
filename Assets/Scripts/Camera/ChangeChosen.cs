using Scenes;
using Scenes.Scene;
using UnityEngine;

public class ChangeChosen : MonoBehaviour
{
    void Update()
    {
        GameModel.Instance.Camera.ChosenEntity = GameModel.Instance.ChosenPlayer;
    }
}
