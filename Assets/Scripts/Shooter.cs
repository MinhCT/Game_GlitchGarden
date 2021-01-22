using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] GameObject gun = null;

    AttackerSpawner myAttackerSpawner;
    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneAttackerSpawner();
        CreateProjectileParent();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneAttackerSpawner()
    {
        AttackerSpawner[] attackerSpawners = AttackerSpawner.AttackerSpawners.ToArray();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            bool isOnRange = Mathf.Abs(Mathf.Floor(attackerSpawner.transform.position.y) - transform.position.y) <= Mathf.Epsilon;
            if (isOnRange)
            {
                myAttackerSpawner = attackerSpawner;
                break;
            }
        }
    }

    public void Fire()
    {
        if (!projectilePrefab)
        {
            Debug.LogWarning("No projectile prefab has been assigned!");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
        projectile.transform.parent = projectileParent.transform;
    }

    private bool IsAttackerInLane()
    {
        return myAttackerSpawner && myAttackerSpawner.transform.childCount > 0;
    }
}
