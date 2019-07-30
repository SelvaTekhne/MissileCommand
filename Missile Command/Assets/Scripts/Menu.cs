using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public static bool isPlay = false;
    public GameObject PlayButton;
    public GameObject ProtectText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
    }

    public void PlayIt()
    {
        isPlay = true;
        PlayButton.SetActive(false);
        ProtectText.SetActive(false);

    }

    public void ReturnMenu()
    {
        isPlay = false;
        PlayButton.SetActive(true);
        ProtectText.SetActive(true);

    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
