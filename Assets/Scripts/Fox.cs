using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;
    bool hasJumped = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        GameObject target = otherGameObject.gameObject;
        if (target.GetComponent<Defender>())
        {
            if (!hasJumped)
            {
                TriggerJumpAnimation();
            }
            else
            {
                Attacker attacker = GetComponent<Attacker>();
                attacker.Attack(target);
            }
        }
    }

    private void TriggerJumpAnimation()
    {
        if (animator)
        {
            animator.SetTrigger("jumpTrigger");
            hasJumped = true;
        }
        else
        {
            Debug.LogWarning("No animator component found on this object!");
        }
    }
}
