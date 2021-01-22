using UnityEngine;

public class LevelProgressMusic : MonoBehaviour
{
    public void StopMusic()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
