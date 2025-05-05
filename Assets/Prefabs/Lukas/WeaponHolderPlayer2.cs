using UnityEngine;

public class WeaponHolderPlayer2 : MonoBehaviour
{
    public Weapon sword;
    public Weapon hammer;

    private Weapon currentWeapon;

    // For Player 2
    public KeyCode player2EquipAndAttackSword = KeyCode.U;  // Equip and attack with sword for Player 2
    public KeyCode player2EquipAndAttackHammer = KeyCode.O; // Equip and attack with hammer for Player 2

    void Start()
    {
        EquipWeapon(sword); // Default weapon for Player 2 (can be customized)
    }

    void Update()
    {
        // Player 2 controls
        if (Input.GetKeyDown(player2EquipAndAttackSword))
        {
            EquipWeapon(sword);  // Equip sword for Player 2
            currentWeapon?.Attack();  // Attack with sword
        }
        else if (Input.GetKeyDown(player2EquipAndAttackHammer))
        {
            EquipWeapon(hammer); // Equip hammer for Player 2
            currentWeapon?.Attack(); // Attack with hammer
        }
    }

    void EquipWeapon(Weapon weaponToEquip)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false); // Hide the previous weapon
        }

        currentWeapon = weaponToEquip;  // Set new weapon
        currentWeapon.gameObject.SetActive(true);  // Activate the new weapon
    }
}
