using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MenuElement : MonoBehaviour
{
    [SerializeField] private SubSoundSource m_subSource;
    [SerializeField] private GameObject m_content;
    [SerializeField] private SoundManager m_soundManager;

    private const string MenuOpen = "MenuOpen";
    private const string MenuClose = "MenuClose";

    public bool IsOpen;
    private void Awake()
    {
        if (m_soundManager == null)
        {
            m_soundManager = GetComponent<SoundManager>();
        }
    }

    private void Start()
    {
        Initialize();
        CloseMenu();
    }

    public virtual void Initialize()
    {
        if (m_soundManager != null && m_subSource != SubSoundSource.None)
        {
            m_soundManager.InitializeSubSounds(m_subSource);
        }
    }
    private void Show()
    {
        IsOpen = true;

        m_content.SetActive(true);
        m_soundManager.PlaySound(MenuOpen);
    }
    
    private void Hide()
    {
        IsOpen = false;

        m_content.SetActive(false);
        m_soundManager.PlaySound(MenuClose);
    }

    // Used in UI elements or scripts
    public virtual void OpenMenu()
    {
        Show();
    }
    public virtual void CloseMenu()
    {
        Hide();
    }
}
