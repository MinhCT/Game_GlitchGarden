using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    Slider levelSlider;
    bool triggerLevelFinished = false;

    private void Start()
    {
        levelSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (triggerLevelFinished) 
            return;

        levelSlider.value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinish = Time.timeSinceLevelLoad >= levelTime;
        
        if (timerFinish)
        {
            LevelController.Instance.LevelTimerFinished();
            triggerLevelFinished = true;
        }
    }
}
