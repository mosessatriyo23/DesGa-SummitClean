using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ContinueGame()
    {
        // Jika belum punya sistem save, sementara samakan saja dengan new game
        SceneManager.LoadScene("Demo");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); 
    }
}
