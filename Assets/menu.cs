using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject uiPauseMenu;
    public GameObject menuOption;

    void Start()
    {
        // Pastikan kondisi awal benar
        mainMenu.SetActive(true);
        uiPauseMenu.SetActive(false);
        menuOption.SetActive(false);
    }

    public void NewGameButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(true);
        uiPauseMenu.SetActive(true);
        menuOption.SetActive(true);
    }

    public void CloseOptions()
    {
        menuOption.SetActive(false);
        uiPauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
