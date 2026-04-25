using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public WeaponBase[] weapons;
    public int currentIndex = 0;

    private bool isFiring;

    void Start()
    {
        EquipWeapon(currentIndex);
    }

    void Update()
    {
        if (isFiring)
        {
            weapons[currentIndex]?.Fire();
        }

        // Scroll wheel input
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll > 0f)
        {
            NextWeapon();
        }
        else if (scroll < 0f)
        {
            PreviousWeapon();
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    public void OnReload()
    {
        weapons[currentIndex]?.Reload();
    }

    //  Switching
    void NextWeapon()
    {
        currentIndex = (currentIndex + 1) % weapons.Length;
        EquipWeapon(currentIndex);
    }

    void PreviousWeapon()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = weapons.Length - 1;

        EquipWeapon(currentIndex);
    }

    void EquipWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }
    }
}