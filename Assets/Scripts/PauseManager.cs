using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseRoot;   // UIPauseMenu
    public GameObject menuPause;   // MenuPause
    public GameObject menuOption;  // MenuOption

    private bool isPaused = false;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Debug.Log("ESC PRESSED");

        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }
}


    public void PauseGame()
    {
        pauseRoot.SetActive(true);
        menuPause.SetActive(true);
        menuOption.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseRoot.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // === OPTIONS ===
    public void OpenOptions()
    {
        menuPause.SetActive(true);
        menuOption.SetActive(true);
    }

    public void CloseOptions()
    {
        menuOption.SetActive(false);
        menuPause.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
