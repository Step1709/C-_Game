using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void RestartGame()
    {
        if (GameModel.Instance.TrainingComleted) SceneManager.LoadScene("GamePlay");
        else SceneManager.LoadScene("Training");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}