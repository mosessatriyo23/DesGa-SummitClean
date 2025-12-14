using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinCollect : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip collectSound;
    [Range(0f, 1f)]
    public float volume = 1.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySoundAndDestroy();
        }
    }

    void PlaySoundAndDestroy()
    {
        if (collectSound != null)
        {

            AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
        }

        Destroy(gameObject);
    }
}