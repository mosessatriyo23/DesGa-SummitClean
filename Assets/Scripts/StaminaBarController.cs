using UnityEngine;
using UnityEngine.UI;

public class StaminaBarController : MonoBehaviour
{
    public static StaminaBarController instance;

    [Header("UI Reference")]
    public Image fillBar;

    private float targetFill = 1f;
    public float speed = 5f;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateBar(float currentStamina, float maxStamina)
    {
        targetFill = currentStamina / maxStamina;
    }

    private void Update()
    {

        if (fillBar != null)
        {
            fillBar.fillAmount = Mathf.Lerp(fillBar.fillAmount, targetFill, Time.deltaTime * speed);
        }
    }
}