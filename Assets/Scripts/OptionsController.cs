using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider = null;
    [SerializeField] float defaultDifficulty = 0;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        MusicPlayer.Instance.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        SceneLoader.Instance.LoadStartScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
