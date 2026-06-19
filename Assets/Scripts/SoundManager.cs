using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundSource m_source;
    [SerializeField] private Transform m_mainSoundsRoot;
    [SerializeField] private Transform m_subSoundsRoot;

    private Dictionary<string, SoundEffectSource> m_audioSources = new Dictionary<string, SoundEffectSource>();

    private const string AudioSourceBaseName = "Sound";

    private void Start()
    {
        InitializeGenericSounds();
    }
    public void InitializeGenericSounds()
    {
        var soundDatas = SoundLibrary.Instance.GetSoundDatas(m_source);

        var soundPrefab = PersistentData.Instance.SoundEffectPrefab;
        if (soundPrefab == null)
        {
            Debug.LogWarning("No sound prefab found!");
            return;
        }

        foreach (var data in soundDatas)
        {
            if (m_audioSources.ContainsKey(data.Tag) || data.SubSource != SubSoundSource.None)
                continue;

            var audioSource = Instantiate(soundPrefab, transform.position, Quaternion.identity, m_mainSoundsRoot);
            audioSource.SetUpAudioSource(data.Clip);
            audioSource.gameObject.name = $"{data.Tag} {AudioSourceBaseName}";

            m_audioSources.Add(data.Tag, audioSource);
        }
    }

    public void InitializeSubSounds(SubSoundSource subSource)
    {
        var soundDatas = SoundLibrary.Instance.GetSoundDatasBySubSource(m_source, subSource);

        var soundPrefab = PersistentData.Instance.SoundEffectPrefab;
        if (soundPrefab == null)
        {
            Debug.LogWarning("No sound prefab found!");
            return;
        }

        foreach (var data in soundDatas)
        {
            if (m_audioSources.ContainsKey(data.Tag))
                continue;

            var audioSource = Instantiate(soundPrefab, transform.position, Quaternion.identity, m_subSoundsRoot);
            audioSource.SetUpAudioSource(data.Clip);
            audioSource.gameObject.name = $"{data.Tag} {AudioSourceBaseName}";

            m_audioSources.Add(data.Tag, audioSource);
        }
    }

    public void PlaySound(string tag)
    {
        if (m_audioSources.TryGetValue(tag, out SoundEffectSource sfx))
        {
            sfx.Play();
        }
    }
}
