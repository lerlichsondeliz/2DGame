using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public Button start;
    public Button options;
    public Button resume;
    public Button help;
    public Button sound;
    public TextMeshProUGUI gameTitleText;
    public Image backgroundImage;
    public TMP_FontAsset outdoorFont;
    
    

    public void Start() {

        gameTitleText.text = "overgrown";
        
        if (backgroundImage != null)
        {
            backgroundImage.type = Image.Type.Sliced;
        }

        if (gameTitleText != null && outdoorFont != null)
        {
            gameTitleText.font = outdoorFont;
            gameTitleText.fontSize = 50;
            gameTitleText.color = Color.black;
            gameTitleText.outlineWidth = 0.5f;
            gameTitleText.outlineColor = Color.black;
        }

        // where button takes you 
        start.onClick.AddListener(startGame);
        options.onClick.AddListener(showOptions);
        resume.onClick.AddListener(resumeLevel);
        
    }

    public void startGame() {
       // for testing button functionality 
        Debug.Log("starting :P");
    }

    public void showOptions() {
        Debug.Log("options menu");
        if (menu != null) menu.SetActive(false); // Hide main menu for options menu 
        if (optionsMenu != null) {
            optionsMenu.SetActive(true);        // Show options menu
            help.onClick.AddListener(showHelp);
            sound.onClick.AddListener(soundFunc);
        }
        Debug.Log("showOptions() finished");
    }

    public void showHelp() {
        Debug.Log("help menu displaying");
        if (optionsMenu != null) {
            optionsMenu.SetActive(false);
        }
        if (helpMenu != null) {
            helpMenu.SetActive(true);
        }
        Debug.Log("showHelp() finished");
    }

    public void soundFunc() {
        Debug.Log("beep music beep");
    }

    public void resumeLevel() {
        Debug.Log("picking up where you left off");
    }
}        