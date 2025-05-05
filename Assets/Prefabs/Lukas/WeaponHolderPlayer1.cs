using UnityEngine;

public class WeaponHolderPlayer1 : MonoBehaviour
{
    public Weapon sword;
    public Weapon hammer;

    private Weapon currentWeapon;

    // For Player 1
    public KeyCode player1EquipAndAttackSword = KeyCode.Q;  // Equip and attack with sword for Player 1
    public KeyCode player1EquipAndAttackHammer = KeyCode.E; // Equip and attack with hammer for Player 1

    void Start()
    {
        EquipWeapon(sword); // Default weapon for Player 1 (can be customized)
    }

    void Update()
    {
        // Player 1 controls
        if (Input.GetKeyDown(player1EquipAndAttackSword))
        {
            EquipWeapon(sword);  // Equip sword for Player 1
            currentWeapon?.Attack();  // Attack with sword
        }
        else if (Input.GetKeyDown(player1EquipAndAttackHammer))
        {
            EquipWeapon(hammer); // Equip hammer for Player 1
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
