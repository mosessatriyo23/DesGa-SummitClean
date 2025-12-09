using UnityEngine;
using UnityEngine.UI;

public class StaminaBarController : MonoBehaviour
{
    public static StaminaBarController instance;

    [Header("UI Reference")]
    public Image fillBar; // Masukkan gambar TrashBarFill (yang petir/merah) ke sini

    private float targetFill = 1f;
    public float speed = 5f; // Kecepatan animasi bar

    private void Awake()
    {
        instance = this;
    }

    // Fungsi ini dipanggil oleh StaminaManager
    public void UpdateBar(float currentStamina, float maxStamina)
    {
        targetFill = currentStamina / maxStamina;
    }

    private void Update()
    {
        // Animasi smooth menggunakan Lerp, sama seperti TrashBarController
        if (fillBar != null)
        {
            fillBar.fillAmount = Mathf.Lerp(fillBar.fillAmount, targetFill, Time.deltaTime * speed);
        }
    }
}