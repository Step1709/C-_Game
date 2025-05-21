using Scenes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    public GameObject PauseGameMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameModel.Instance.OnPause)
                Resume();
            else
                Pause();
        }
    }
    
    public void Resume()
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        GameModel.Instance.OnPause = false;
    }

    public void Pause()
    {
        PauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        GameModel.Instance.OnPause = true;
    }

    public void LoadMenu()
    {
        GameModel.Instance.OnPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
