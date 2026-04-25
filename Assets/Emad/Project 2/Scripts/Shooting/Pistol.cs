using UnityEngine;

public class Pistol : WeaponBase
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 25f;

    protected override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}
