using System.IO;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (GameModel.Instance.TrainingComleted == 1) SceneManager.LoadScene("GamePlay");
        else SceneManager.LoadScene("Training");
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("TrainingComleted", GameModel.Instance.TrainingComleted);
        Application.Quit();
        Debug.Log("выход из игры");
    }
}
