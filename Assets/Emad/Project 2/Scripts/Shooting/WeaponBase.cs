using UnityEngine;
using System.Collections;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    [Header("Weapon Stats")]
    public int damage = 10;
    public float fireRate = 2f;

    [Header("Ammo")]
    public int magazineSize = 10;
    public int currentAmmo;
    public int reserveAmmo = 50;

    [Header("Reload")]
    public float reloadTime = 2f;

    [Header("References")]
    public Transform firePoint;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip fireSound;
    public AudioClip reloadSound;

    // Weapon UI
    public int CurrentAmmo => currentAmmo;
    public int ReserveAmmo => reserveAmmo;
    public string WeaponName => gameObject.name;

    protected float nextFireTime = 0f;
    protected bool isReloading = false;

    protected virtual void Start()
    {
        currentAmmo = magazineSize;
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public virtual void Fire()
    {
        if (isReloading) return;

        if (Time.time < nextFireTime) return;

        if (currentAmmo <= 0)
        {
            Reload();
            return;
        }

        nextFireTime = Time.time + 1f / fireRate;

        currentAmmo--;

        // Fire sound effect
        if (fireSound != null)
            audioSource.PlayOneShot(fireSound);

        Shoot();
    }

    public virtual void Reload()
    {
        if (isReloading) return;
        if (currentAmmo == magazineSize) return;
        if (reserveAmmo <= 0) return;

        StartCoroutine(ReloadRoutine());
    }

    protected virtual IEnumerator ReloadRoutine()
    {
        isReloading = true;
        
        // Reload sound effect 
        if (reloadSound != null)
            audioSource.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(reloadTime);

        int neededAmmo = magazineSize - currentAmmo;
        int ammoToLoad = Mathf.Min(neededAmmo, reserveAmmo);

        currentAmmo += ammoToLoad;
        reserveAmmo -= ammoToLoad;

        isReloading = false;
    }

    protected abstract void Shoot();
}