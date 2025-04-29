using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {


    public PlayerHealth player1Health; 
    public PlayerHealth player2Health; 
    private Slider healthBarSlider;
    private float combinedMaxHealth;
    public Button exitGame;

    public void Start() {
    
        combinedMaxHealth = player1Health.maxHealth + player2Health.maxHealth;
        healthBarSlider.maxValue = combinedMaxHealth;

            // Set the initial value to the combined max health
        healthBarSlider.value = combinedMaxHealth;
    }

     public void Update() {
    
        if (healthBarSlider != null && player1Health != null && player2Health != null)
        {
            // Calculate the combined current health
            float combinedCurrentHealth = player1Health.CurrentHealth + player2Health.CurrentHealth;
            healthBarSlider.value = combinedCurrentHealth;
        }
    }

    public void levelExit() {
        SceneManager.LoadScene("UIScene");
    }

}
