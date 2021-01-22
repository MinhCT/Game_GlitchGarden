using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        GameObject target = otherGameObject.gameObject;
        Attacker attacker = GetComponent<Attacker>();
        if (target.GetComponent<Defender>() && attacker)
        {
            attacker.Attack(target);
        }
    }
}
