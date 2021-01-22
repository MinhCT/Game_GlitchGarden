using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;
    [SerializeField] GameObject defenderSpawnerRef = null;

    DefenderSpawner defenderSpawner;

    private void Start()
    {
        defenderSpawner = defenderSpawnerRef.GetComponent<DefenderSpawner>();
        LabelButtonsWithCost();
    }

    private void LabelButtonsWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning("Button for Defender: " + name + " has no cost text!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = transform.parent.GetComponentsInChildren<DefenderButton>(true);
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(75, 75, 75, 255);
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            spriteRenderer.color = Color.white;
        }
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
