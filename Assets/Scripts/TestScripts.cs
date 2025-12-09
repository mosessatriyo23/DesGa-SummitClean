using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{

    [SerializeField] private ConfirmationWindow myConfirmationWindow;
    [SerializeField] public TrashManager myTrashManager;

    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow("Tutorial Level");
    }

    private void OpenConfirmationWindow(string message)
    {
        if (myTrashManager == null) return;

        myConfirmationWindow.gameObject.SetActive(true);
        myConfirmationWindow.LetsgoButton.onClick.AddListener(LetsgoClicked);
        myConfirmationWindow.messageText.text = message;
    }

    private void LetsgoClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Let go clicked");
    }

    public void ShowLevelComplete()
    {
        myConfirmationWindow.gameObject.SetActive(true);
        myConfirmationWindow.LetsgoButton.onClick.AddListener(LetsgoClicked);
        myConfirmationWindow.messageText.text = "Level Complete";
    }

}
