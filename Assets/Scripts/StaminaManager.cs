using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;

    [Header("Stamina Settings")]
    public float currentStamina = 100f;
    public float maxStamina = 100f;

    [Header("Drain Settings")]
    public float walkDrain = 1f;
    public float runDrain = 5f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        currentStamina = maxStamina;
        UpdateUI();
    }

    private void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool isMoving = moveX != 0 || moveY != 0;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
        {

            if (isRunning && currentStamina > 0)
            {
                DrainStamina(runDrain);
            }

            else
            {
                DrainStamina(walkDrain);
            }
        }

    }

    private void DrainStamina(float amount)
    {
        currentStamina -= amount * Time.deltaTime;
        
        if (currentStamina < 0) currentStamina = 0;

        UpdateUI();
    }


    public void AddStamina(float amount)
    {
        currentStamina += amount;

        if (currentStamina > maxStamina) currentStamina = maxStamina;


        
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (StaminaBarController.instance != null)
        {
            StaminaBarController.instance.UpdateBar(currentStamina, maxStamina);
        }
    }
}