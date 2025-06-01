using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}