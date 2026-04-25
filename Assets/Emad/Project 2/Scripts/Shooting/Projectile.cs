using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        // Check tag to not interact with itself
        if (collision.gameObject.CompareTag("itself"))
            return;

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
