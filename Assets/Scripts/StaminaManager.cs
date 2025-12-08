using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;

    [Header("Stamina Settings")]
    public float currentStamina = 100f;
    public float maxStamina = 100f;

    [Header("Drain Settings")]
    public float walkDrain = 1f;  // Stamina berkurang pelan saat jalan
    public float runDrain = 5f;   // Stamina berkurang cepat saat lari

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Update UI saat game mulai
        currentStamina = maxStamina;
        UpdateUI();
    }

    private void Update()
    {
        // Cek input gerakan (WASD / Panah)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool isMoving = moveX != 0 || moveY != 0;

        // Cek input lari (Shift)
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Jika bergerak (tidak diam)
        if (isMoving)
        {
            // Jika tombol Shift ditekan DAN Stamina masih ada -> Gunakan Run Drain
            if (isRunning && currentStamina > 0)
            {
                DrainStamina(runDrain);
            }
            // Jika tidak tekan Shift -> Gunakan Walk Drain
            else
            {
                DrainStamina(walkDrain);
            }
        }
        // Opsional: Jika diam, bisa tambah logika regenerasi stamina di sini (else)
    }

    // Fungsi mengurangi stamina (Sekarang menerima parameter amount)
    private void DrainStamina(float amount)
    {
        currentStamina -= amount * Time.deltaTime;
        
        if (currentStamina < 0) currentStamina = 0;

        UpdateUI();
    }

    // Fungsi menambah stamina (Dipanggil oleh Buah)
    public void AddStamina(float amount)
    {
        currentStamina += amount;

        if (currentStamina > maxStamina) currentStamina = maxStamina;

        // Debug.Log("AddStamina dipanggil. Nilai sekarang: " + currentStamina);
        
        UpdateUI();
    }

    // Helper untuk memanggil update UI ke Controller
    private void UpdateUI()
    {
        if (StaminaBarController.instance != null)
        {
            StaminaBarController.instance.UpdateBar(currentStamina, maxStamina);
        }
    }
}