using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelProgressMusicRef = null;
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;
    [SerializeField] float waitToLoad = 4f;

    private static LevelController _instance;

    public static LevelController Instance { get { return _instance; } }

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

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
        }
    }

    private void Start()
    {
        DestroyMainMenuMusic();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerEliminated()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        StopLevelProgressMusic();
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(waitToLoad);
        SceneLoader.Instance.LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = AttackerSpawner.AttackerSpawners.ToArray();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

    private void StopLevelProgressMusic()
    {
        if (levelProgressMusicRef)
        {
            levelProgressMusicRef.GetComponent<LevelProgressMusic>().StopMusic();
        }
    }

    private void DestroyMainMenuMusic()
    {
        if (MusicPlayer.Instance)
        {
            MusicPlayer.Instance.DestroyMusicPlayer();
        }
    }
}
