using UnityEngine;

public class StaminaFruit : MonoBehaviour
{
    public float amountToAdd = 20f; // Jumlah stamina yang ditambah

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pastikan Player punya Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Panggil fungsi AddStamina milik Manager (menggunakan Instance)
            if (StaminaManager.instance != null)
            {
                StaminaManager.instance.AddStamina(amountToAdd);
                
                // Hancurkan buah
                Destroy(gameObject);
            }
        }
    }
}