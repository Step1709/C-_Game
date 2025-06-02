using System.IO;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (GameModel.Instance.TrainingComleted) SceneManager.LoadScene("GamePlay");
        else SceneManager.LoadScene("Training");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("выход из игры");
    }
}
