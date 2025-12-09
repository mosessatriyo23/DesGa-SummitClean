using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteAll(); // hapus data lama
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("loadLevel", 1);
    }

    public void ContinueGame()
    {
        if (!PlayerPrefs.HasKey("lastScene")) return;
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("loadLevel", PlayerPrefs.GetInt("lastScene"));
    }

    public void Options()
    {
        Debug.Log("Options menu belum dibuat.");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
