using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public GameObject soundMenu;
    private GameObject currentMenu;
    public Button start;
    public Button options;
    public Button resume;
    public Button help;
    public Button sound;
    public Button back;
    public TextMeshProUGUI gameTitleText;
    public Image backgroundImage;
    public TMP_FontAsset outdoorFont;
    public Toggle musicToggle;
    public AudioSource musicAudioSource;
    
    

    public void Start() {

        currentMenu = menu;
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

        if (musicToggle != null)
        {
            musicToggle.onValueChanged.AddListener(music);
        }
        
    }

    public void startGame() {
       // for testing button functionality 
        Debug.Log("starting :P");
        SceneManager.LoadScene("Level1");
        //Level.firstLevel();
    }

    public void showOptions() {
        Debug.Log("options menu");
        if (menu != null)  {
            menu.SetActive(false);
        }  
        if (optionsMenu != null) {
            optionsMenu.SetActive(true);        // show options menu
            currentMenu = optionsMenu; 
            help.onClick.AddListener(showHelp);
            sound.onClick.AddListener(soundFunc);
        }
        back.onClick.AddListener(goBack);
    }

    public void showHelp() {
        Debug.Log("help menu displaying");
        if (optionsMenu != null) {
            optionsMenu.SetActive(false);
        }
        if (helpMenu != null) {
            helpMenu.SetActive(true);
            currentMenu = helpMenu; 
        }
        back.onClick.AddListener(goBack);
    }

    public void soundFunc() {
        Debug.Log("beep music beep");
        if (optionsMenu != null) {
            optionsMenu.SetActive(false);
        }
        if (soundMenu != null) {
            soundMenu.SetActive(true);
            currentMenu = soundMenu; 
        }
        back.onClick.AddListener(goBack);
    }

    public void resumeLevel() {
        Debug.Log("picking up where you left off");
    }

    public void goBack() {
        if (currentMenu != optionsMenu) {
            currentMenu = optionsMenu;
            optionsMenu.SetActive(true);
            soundMenu.SetActive(false);
            helpMenu.SetActive(false);
        }
        else {
            currentMenu = menu;
            menu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    
    }

    public void music(bool isMusicOn) {
        Debug.Log("music toggle: " + isMusicOn);
       if (musicAudioSource != null) 
        {
            musicAudioSource.mute = !isMusicOn;
        }
    }
}        