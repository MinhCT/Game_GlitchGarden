using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;
    public static MusicPlayer Instance { get { return _instance; } }

    AudioSource audioSource;

    private void Awake()
    {
        if (_instance && _instance != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void DestroyMusicPlayer()
    {
        Destroy(gameObject);
    }
}
