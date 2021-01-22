using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] float destroyCollidedObjectAfter = 1f;
    [SerializeField] GameObject liveDisplayRef = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        liveDisplayRef.GetComponent<LiveDisplay>().TakeLife();
        Destroy(collision.gameObject, destroyCollidedObjectAfter);
    }
}
