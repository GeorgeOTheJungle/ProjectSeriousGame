using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_musicValueLabel;
    [SerializeField] private Slider m_musicSlider;

    [SerializeField] private TextMeshProUGUI m_soundValueLabel;
    [SerializeField] private Slider m_soundsSlider;


    private void Start()
    {
        UpdateSlider(m_musicSlider, m_musicValueLabel, SoundLibrary.Instance.GetMusicVolume());
        UpdateSlider(m_soundsSlider, m_soundValueLabel, SoundLibrary.Instance.GetSoundVolume());
    }

    public void UpdateMusicVolume()
    {
        float sliderValue = Mathf.Round(m_musicSlider.value * 10f) / 10f;

        UpdateSlider(m_musicSlider, m_musicValueLabel, sliderValue);
        SoundLibrary.Instance.ChangeMusicVolume(sliderValue);

        SoundLibrary.Instance.ToggleBackgroundMusic(sliderValue != 0);
    }

    public void UpdateSoundEffectsVolume()
    {
        float sliderValue = Mathf.Round(m_soundsSlider.value * 10f) / 10f;

        UpdateSlider(m_soundsSlider, m_soundValueLabel, sliderValue);
        SoundLibrary.Instance.ChangeSoundVolume(sliderValue);

        SoundLibrary.Instance.ToggleSoundEffects(sliderValue != 0);
    }

    private void UpdateSlider(Slider slider, TextMeshProUGUI label, float value)
    {
        slider.value = value;
        label.SetText(value.ToString((value == 1 || value == 0) ? "" : "F1"));
    }
}
