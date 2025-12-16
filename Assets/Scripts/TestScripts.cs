using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScripts : MonoBehaviour
{
    // Ini adalah variabel statis yang akan tetap ada saat berpindah scene
    public static bool isFirstLoad = true; 

    [SerializeField] private ConfirmationWindow myConfirmationWindow;
    [SerializeField] public TrashManager myTrashManager;  

    [SerializeField] private ConfirmationNext myConfirmationNext;

    // Start is called before the first frame update
    void Start()
    {
        // Cek apakah ini adalah pemuatan pertama (saat tutorial harus muncul)
        if (isFirstLoad) 
        {
            if (myConfirmationWindow != null)
            {
                myConfirmationWindow.gameObject.SetActive(false);
            }
            // Tampilkan jendela konfirmasi hanya pada pemuatan pertama
            OpenConfirmationWindow("Tutorial Level");

            // Setelah ditampilkan, atur isFirstLoad menjadi false
            // Ini akan mencegahnya muncul lagi di scene berikutnya
            isFirstLoad = false; 
        }
        else 
        {
            // Jika ini bukan pemuatan pertama (misalnya Level 2), 
            // pastikan jendela konfirmasi dinonaktifkan sepenuhnya.
            if (myConfirmationWindow != null)
            {
                myConfirmationWindow.gameObject.SetActive(false);
            }
            if (myConfirmationNext != null)
            {
                myConfirmationNext.gameObject.SetActive(false);
            }
            OpenConfirmationWindow("Level 2 Lets go!");
            // Tidak perlu memanggil OpenConfirmationWindow di sini.
        }
    }

    private void OpenConfirmationWindow(string message)
    {
        // ... (Kode Anda yang lain tetap sama)
        myConfirmationWindow.gameObject.SetActive(true);
        myConfirmationWindow.LetsgoButton.onClick.AddListener(LetsgoClicked);
        myConfirmationWindow.messageText.text = message;
        myConfirmationNext.gameObject.SetActive(false);
    }

    // ... (Fungsi LetsgoClicked, OpenLevel, ShowLevelComplete Anda yang lain)

    private void LetsgoClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Let go clicked");
    }

    private void OpenLevel()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        SceneManager.LoadScene("Level2Beneran");
    }

    public void ShowLevelComplete()
    {
        myConfirmationNext.gameObject.SetActive(true);
        myConfirmationNext.LvlButton.onClick.AddListener(OpenLevel);
        myConfirmationNext.LvlText.text = "Level Complete go to next level!";
    }
}