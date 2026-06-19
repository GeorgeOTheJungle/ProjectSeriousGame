using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static Unity.VisualScripting.Member;

public class SoundLibrary : MonoBehaviour
{
    public static SoundLibrary Instance;

    [SerializeField]
    private PlayerOptions Settings;

    public SoundData[] Sounds;

    [Serializable]
    public struct SoundData
    {
        [Tooltip("Tag that is used to find this sound in the sound controller, keep it simple.")]
        public string Tag; // Note: Don't use numbers here.

        [Tooltip("Who is the sound for, used to grab all the sounds from an object.")]
        public SoundSource Source; // Main enum to use objects
        public SubSoundSource SubSource; // This enum will change depending the game, but lets try and keep the naming as clear as possible.

        [Space]
        public AudioClip Clip; 
    }

    // TODO: This may be uploaded to player prefs or something like that...
    [Serializable]
    public struct PlayerOptions
    {
        public bool MusicEnabled;
        public bool SoundsEnabled;

        public float MusicVolume;
        public float SoundVolume;
    }
    // All audio sources will play a clip, if they don't have any, by default they are going to play this sound that should be really clear we are missing something...
    public AudioClip DefaultMissingSound;

    // Events for Sound effects and music managers.
    public Action<PlayerOptions> OnSettingsChanged;
    public Action<float> OnSoundEffectsVolumeChanged;
    public Action<float> OnMusicVolumeChanged;

    public Action<bool> OnToggleSoundsChanged;
    public Action<bool> OnToggleMusicChanged;

    private void Awake()
    {
        Instance = this;
    }

    public List<SoundData> GetSoundDatas(SoundSource source)
    {
        var result = new List<SoundData>();

        foreach(var sound in Sounds)
        {
            if (sound.Source == source)
            {
                result.Add(sound);
            }
        }

        return result;
    }

    public List<SoundData> GetSoundDatasBySubSource(SoundSource source, SubSoundSource subSource)
    {
        var result = new List<SoundData>();

        foreach (var sound in Sounds)
        {
            if (sound.Source == source && sound.SubSource == subSource)
            {
                result.Add(sound);
            }
        }

        return result;
    }

    public List<AudioClip> GetClip(SoundSource source, string tag)
    {
        var result = new List<AudioClip>();
        foreach (var sound in Sounds)
        {
            if (sound.Source == source && sound.Tag == tag)
            {
                result.Add(sound.Clip);
            }
        }

        return result;
    }

    // Player Settings
    public void ToggleSoundEffects(bool enabled)
    {
        Settings.SoundsEnabled = enabled;
        OnToggleSoundsChanged?.Invoke(enabled);
    }

    public void ToggleBackgroundMusic(bool enabled)
    {
        Settings.MusicEnabled = enabled;
        OnToggleMusicChanged?.Invoke(enabled);
    }

    public void ChangeMusicVolume(float newValue)
    {
        Settings.MusicVolume = newValue;
        OnMusicVolumeChanged?.Invoke(Settings.SoundVolume);
    }

    public void ChangeSoundVolume(float newValue)
    {
        Settings.SoundVolume = newValue;
        OnSoundEffectsVolumeChanged?.Invoke(Settings.SoundVolume);
    }

    public float GetMusicVolume()
    {
        return Settings.MusicVolume;
    }

    public float GetSoundVolume()
    {
        return Settings.SoundVolume;
    }


}

public enum SoundSource
{
    Player,
    Enemy,
    Menu,
}

// Use this to find the correct source
public enum SubSoundSource
{
    None, // To always include the item
    Settings
}