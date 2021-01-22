using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5f)]
    [SerializeField] float currentSpeed = 1f;

    LevelController levelController;
    Animator attacker;
    GameObject currentTarget;

    private void Awake()
    {
        levelController = LevelController.Instance;
        levelController.AttackerSpawned();
    }

    private void Start()
    {
        attacker = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        if (levelController)
        {
            levelController.AttackerEliminated();
        }
    }

    void Update()
    {
        if (!currentTarget) UpdateAnimationState(false);
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        UpdateAnimationState(true);
        currentTarget = target;
    }

    public void DamageTarget(float damage)
    {
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
        else
        {
            Debug.LogWarning("No health component found on this Attacker!");
        }
    }

    public void UpdateAnimationState(bool isAttacking)
    {
        if (attacker)
        {
            attacker.SetBool("isAttacking", isAttacking);
        }
        else
        {
            Debug.LogWarning("No animator reference found on this object");
        }
    }
}
