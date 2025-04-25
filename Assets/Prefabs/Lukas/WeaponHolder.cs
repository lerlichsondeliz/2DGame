using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon sword;
    public Weapon hammer;

    private Weapon currentWeapon;

    void Start()
    {
        EquipWeapon(sword); // Default weapon
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipWeapon(sword);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            EquipWeapon(hammer);
        }

        // Optional: Attack with current weapon (e.g., left click)
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon?.Attack();
        }
    }

    void EquipWeapon(Weapon weaponToEquip)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = weaponToEquip;
        currentWeapon.gameObject.SetActive(true);
    }
}
