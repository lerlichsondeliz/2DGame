using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon sword;
    public Weapon hammer;

    private Weapon currentWeapon;

    // For Player 1
    public KeyCode player1EquipAndAttackSword = KeyCode.Q;  // Equip and attack with sword for Player 1
    public KeyCode player1EquipAndAttackHammer = KeyCode.E; // Equip and attack with hammer for Player 1

    // For Player 2
    public KeyCode player2EquipAndAttackSword = KeyCode.U;  // Equip and attack with sword for Player 2
    public KeyCode player2EquipAndAttackHammer = KeyCode.O; // Equip and attack with hammer for Player 2

    void Start()
    {
        EquipWeapon(sword); // Default weapon for Player 1 (can be customized)
    }

    void Update()
    {
        // Check if this script is controlling Player 1 or Player 2
        if (CompareTag("Player1"))
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
        else if (CompareTag("Player2"))
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
