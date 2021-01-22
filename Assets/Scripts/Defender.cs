using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = StarDisplay.Instance;
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
