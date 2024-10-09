using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";
    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;

            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 1f);
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);
            }
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.Play();
    }

    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, volume);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 1f);
            }
            else
            {
                continue;
            }
        }
    }

    public float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 1f);
    }
}
