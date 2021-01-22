using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    private static StarDisplay _instance;

    public static StarDisplay Instance { get { return _instance; } }

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

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        stars -= amount;
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return amount <= stars;
    }
}
