using UnityEngine;

public class Shotgun : WeaponBase
{
    public GameObject pelletPrefab;
    public int pelletCount = 8;
    public float spreadAngle = 12f;
    public float pelletSpeed = 15f;

    protected override void Shoot()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            Quaternion spread = Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0
            );

            GameObject pellet = Instantiate(pelletPrefab, firePoint.position, firePoint.rotation * spread);

            Rigidbody rb = pellet.GetComponent<Rigidbody>();
            rb.linearVelocity = pellet.transform.forward * pelletSpeed;
        }
    }
}

