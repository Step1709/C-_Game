using Scenes;
using UnityEngine;

public class GameModelScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameModel.Instance.ChosenPlayer = Ashen.Instance;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameModel.Instance.ChosenPlayer = Biv.Instance;
        }
    }
}