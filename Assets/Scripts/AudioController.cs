using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioController : MonoBehaviour
{
    [Header("ThemeSound")]
    [SerializeField] AudioClip[] themeSounds = null;

    [Header("OtherSound")]
    [SerializeField] AudioClip[] otherSounds = null;

    private AudioSource m_ThemeAudioSource = null;
    private AudioSource m_OtherAudioSource = null;

    void Awake()
    {
        var temp = Camera.main.GetComponentsInChildren<AudioSource>();
        m_ThemeAudioSource = temp[0];
        m_OtherAudioSource = temp[1];
    }
    public void PlayThemeSound(int index,bool isLoop)
    {
        m_ThemeAudioSource.PlayOneShot(themeSounds[index]);
        m_ThemeAudioSource.loop = isLoop;
    }
    public void PlayThemeSound(int index)
    {
        m_ThemeAudioSource.PlayOneShot(themeSounds[index]);
        m_ThemeAudioSource.loop = false;
    }
    public void PlayOtherSound(int index)
    {
        m_OtherAudioSource.PlayOneShot(otherSounds[index]);
    }
}
