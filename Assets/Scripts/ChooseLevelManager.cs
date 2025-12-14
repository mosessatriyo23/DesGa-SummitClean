using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenu;
    public GameObject chooseLevelPanel;

    // === OPEN / CLOSE PANEL ===
    public void OpenChooseLevel()
    {
        chooseLevelPanel.SetActive(true);
        // mainMenu TIDAK dimatikan
    }

    public void CloseChooseLevel()
    {
        chooseLevelPanel.SetActive(false);
    }

    // === LOAD LEVEL ===
    public void StartLevel1()
    {
        SceneManager.LoadScene("Demo"); // SESUAI NAMA SCENE
    }

    // NANTI JIKA MAU
    public void StartLevel2()
    {
        // SceneManager.LoadScene("Level2");
    }
}
