using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get => instance; }

    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        instance = this;

        ToggleMusic(PlayerPrefs.GetInt("music", 1) == 1);
        ToggleSound(PlayerPrefs.GetInt("sound", 1) == 1);
    }

    private void ToggleMixerGroup(string group, bool state)
    {
        mixer.SetFloat(group, (state) ? 0 : -80);

        PlayerPrefs.SetInt(group, state ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleMusic(bool state) {
        ToggleMixerGroup("music", state);
    }
    public void ToggleSound(bool state) {
        ToggleMixerGroup("sound", state);
    }
}
