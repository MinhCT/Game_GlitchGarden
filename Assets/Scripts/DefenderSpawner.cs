using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject starDisplayRef = null;

    Defender defender;
    GameObject defenderParent;
    StarDisplay starDisplay;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        starDisplay = starDisplayRef.GetComponent<StarDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (!defender)
            return;
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        int defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        if (!defender)
        {
            Debug.LogWarning("No defender game object has been assigned!");
            return;
        }
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }
}
