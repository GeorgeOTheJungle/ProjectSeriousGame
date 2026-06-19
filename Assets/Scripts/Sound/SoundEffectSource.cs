using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSource : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        SoundLibrary.Instance.OnToggleSoundsChanged += ToggleAudioSource;
        SoundLibrary.Instance.OnSoundEffectsVolumeChanged += UpdateVolume;
    }

    private void OnDisable()
    {
        SoundLibrary.Instance.OnToggleSoundsChanged -= ToggleAudioSource;
        SoundLibrary.Instance.OnSoundEffectsVolumeChanged -= UpdateVolume;
    }

    public void SetUpAudioSource(AudioClip clip)
    {
        if (clip == null)
        {
            m_audioSource.clip = SoundLibrary.Instance.DefaultMissingSound;
            return;
        }

        m_audioSource.clip = clip;
    }

    public void Play()
    {
        m_audioSource.Play();
    }

    public void Stop()
    {
        m_audioSource.Stop();
    }

    private void ToggleAudioSource(bool value)
    {
        m_audioSource.enabled = value;
    }
    private void UpdateVolume(float value)
    {
        m_audioSource.volume = value;
    }
}
