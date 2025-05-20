using Scenes;
using Unity.VisualScripting;
using UnityEngine;

public class GameModelScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameModel.Instance.MainPlayers.Contains(Ashen.Instance))
        {
            GameModel.Instance.ChosenPlayer = Ashen.Instance;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && GameModel.Instance.MainPlayers.Contains(Biv.Instance))
        {
            GameModel.Instance.ChosenPlayer = Biv.Instance;
        }
    }
}