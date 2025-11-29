using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TrashBarController : MonoBehaviour
{
    public static TrashBarController instance;

    public Image fillBar;
    public TextMeshProUGUI progressText;

    private float targetFill = 0f;
    public float speed = 3f; // semakin besar semakin cepat

    private void Awake()
    {
        instance = this;
    }

    public void UpdateBar(int currentTrash, int maxTrash)
    {
        targetFill = (float)currentTrash / maxTrash;

        // Jika sudah penuh → tampilkan COMPLETED
        if (currentTrash >= maxTrash)
        {
            progressText.text = "COMPLETED";
        }
        else
        {
            progressText.text = currentTrash + " / " + maxTrash;
        }       
    }

    private void Update()
    {
        // smooth animation
        fillBar.fillAmount = Mathf.Lerp(fillBar.fillAmount, targetFill, Time.deltaTime * speed);
    }
}
