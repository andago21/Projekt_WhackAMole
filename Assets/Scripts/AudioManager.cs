using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip hitSound;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "MainMenu") 

        {
            musicSource.Stop();
            musicSource.Play();
        }
    }

    public void PlayHit() => sfxSource.PlayOneShot(hitSound);
    public void PlayMusic() { if (!musicSource.isPlaying) musicSource.Play(); }
    public void StopMusic() => musicSource.Stop();
}