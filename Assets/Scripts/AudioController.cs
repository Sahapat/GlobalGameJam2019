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
    private AudioSource m_extraSound = null;

    void Awake()
    {
        var temp = Camera.main.GetComponentsInChildren<AudioSource>();
        m_ThemeAudioSource = temp[0];
        m_OtherAudioSource = temp[1];
        m_extraSound = temp[2];
    }
    void Update()
    {
        m_ThemeAudioSource.volume = PlayerData.volume;
        m_OtherAudioSource.volume = PlayerData.volume;
    }
    public void PlayThemeSound(int index,bool isLoop)
    {
        m_ThemeAudioSource.Stop();
        m_ThemeAudioSource.PlayOneShot(themeSounds[index]);
        m_ThemeAudioSource.loop = isLoop;
    }
    public void PlayThemeSound(int index)
    {
        m_ThemeAudioSource.Stop();
        m_ThemeAudioSource.PlayOneShot(themeSounds[index]);
        m_ThemeAudioSource.loop = false;
    }
    public void PlayOtherSound(int index)
    {
        m_OtherAudioSource.Stop();
        m_OtherAudioSource.PlayOneShot(otherSounds[index]);
    }
    public void PlayExtraSound(int index)
    {
        m_extraSound.Stop();
        m_extraSound.PlayOneShot(otherSounds[index]);
    }
}
