using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    Options options;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        foreach (Sounds mysounds in sounds)
        {
            mysounds.audioSource = gameObject.AddComponent<AudioSource>();
            mysounds.audioSource.clip = mysounds.clip;
            mysounds.audioSource.volume = mysounds.volume;
            mysounds.audioSource.loop = mysounds.loop;
            mysounds.audioSource.pitch = mysounds.pitch;
        }

        if(PlayerPrefs.HasKey("Music") == false || PlayerPrefs.GetString("Music") == "true") PlayerData.SwitchMusic("true");
    }
    private void Start()
    {
        Play("IntroGameTheme");
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) { Stop("GamePlayTheme"); Play("IntroGameTheme"); }
    }
    public void Play(string name)
    {
        if (PlayerPrefs.GetString("Music") == "true")
        {
            Sounds audio = Array.Find(sounds, sound => sound.Name == name);
            if (audio == null) { Debug.Log("Sound cannot be found"); return; }
            if (!audio.audioSource.isPlaying) { audio.audioSource.Play(); }
        }
        else return;
    }
    public void Stop(string name)
    {
        Sounds audio = Array.Find(sounds, sound => sound.Name == name);
        if (audio.audioSource.isPlaying) { audio.audioSource.Stop(); }
        else return;
    }
}