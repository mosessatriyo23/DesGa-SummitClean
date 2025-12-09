using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    private void Awake()
    {
        // Kode ini membuat objek tidak hancur saat pindah scene
        DontDestroyOnLoad(transform.gameObject); 
    }
}