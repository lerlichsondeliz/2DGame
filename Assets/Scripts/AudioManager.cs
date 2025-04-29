using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic; 

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 

    [System.Serializable]
    public class SceneAudio
    {
        public string sceneName;
        public AudioSource audioSource;
    }

    public List<SceneAudio> sceneAudioSources = new List<SceneAudio>(); // List of scene-specific AudioSources
    public Toggle musicToggle;      // Assign in Inspector

    private string currentSceneName;
    private AudioSource currentAudioSource;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the AudioManager persist
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;
        }
    }

    void Start()
    {
        // Get the current scene name
        currentSceneName = SceneManager.GetActiveScene().name;
        PlayMusicForScene(currentSceneName);

        // Set up the music toggle listener
        if (musicToggle != null)
        {
            musicToggle.onValueChanged.AddListener(OnMusicToggleValueChanged);
        }

        // Subscribe to scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = scene.name;
        PlayMusicForScene(currentSceneName);
    }

    void PlayMusicForScene(string sceneName)
    {
        // Stop current music
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
            currentAudioSource = null; // Reset
        }

        // Find and play the AudioSource for the new scene
        foreach (SceneAudio sceneAudio in sceneAudioSources)
        {
            if (sceneAudio.sceneName == sceneName && sceneAudio.audioSource != null)
            {
                currentAudioSource = sceneAudio.audioSource;
                currentAudioSource.Play();
                return; // Exit the loop once found
            }
        }
        // If no music is found for the scene, no music will play.
    }

    void OnMusicToggleValueChanged(bool isMusicOn)
    {
        Debug.Log("Music Toggle: " + isMusicOn);
        // Mute/unmute the currently playing music
        if (currentAudioSource != null)
        {
            currentAudioSource.mute = !isMusicOn;
        }
    }
}
