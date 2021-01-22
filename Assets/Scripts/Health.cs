using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationsOfExplosion = 0.8f;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        GameObject particles = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(particles, durationsOfExplosion);
    }
}
