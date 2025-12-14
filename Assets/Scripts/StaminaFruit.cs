using UnityEngine;

public class StaminaFruit : MonoBehaviour
{
    public float amountToAdd = 20f; 

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            if (StaminaManager.instance != null)
            {
                StaminaManager.instance.AddStamina(amountToAdd);
                

                Destroy(gameObject);
            }
        }
    }
}