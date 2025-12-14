using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); 
    }
}