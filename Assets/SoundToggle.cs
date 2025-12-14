using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public GameObject onIcon;
    public GameObject offIcon;

    private bool isMuted = false;

    public void ToggleSound()
    {
        isMuted = !isMuted;

        AudioListener.pause = isMuted;

        onIcon.SetActive(!isMuted);
        offIcon.SetActive(isMuted);
    }
}
