using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TrashManager.instance.AddTrash();
            Destroy(gameObject);
        }
    }
}
