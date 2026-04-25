using UnityEngine;

public class RocketLauncher : WeaponBase
{
    public GameObject rocketPrefab;
    public float rocketSpeed = 10f;

    protected override void Shoot()
    {
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * rocketSpeed;
    }
}