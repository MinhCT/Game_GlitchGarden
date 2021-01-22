using UnityEngine;
using UnityEngine.UI;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    
    float lives;
    Text livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        if (lives >= damage)
        {
            lives -= damage;
            UpdateDisplay();
        }

        if (lives <= 0)
        {
            LevelController.Instance.HandleLoseCondition();
        }
    }
}
