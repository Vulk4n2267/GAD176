using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public WeaponController weaponController;

    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI ammoText;

    void Update()
    {
        WeaponBase weapon = weaponController.weapons[weaponController.currentIndex];

        if (weapon == null) return;

        weaponText.text = weapon.WeaponName;
        ammoText.text = weapon.CurrentAmmo + " / " + weapon.ReserveAmmo;
    }
}