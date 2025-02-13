using UnityEngine;

public class PlayUISound : MonoBehaviour
{
    void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
