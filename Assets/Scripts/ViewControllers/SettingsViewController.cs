using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class SettingsViewController : ViewController
{
    [SerializeField] private VectorImage musicOn;
    [SerializeField] private VectorImage musicOff;
    [SerializeField] private VectorImage soundOn;
    [SerializeField] private VectorImage soundOff;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private BaseButtonController musicBtn = new BaseButtonController();
    [SerializeField] private BaseButtonController soundBtn = new BaseButtonController();
    private bool musicEnabled;
    private bool soundEnabled;

    public bool Music
    {
        get => musicEnabled;
        set
        {
            musicEnabled = value;
            musicBtn.ChangeBackgroundImage((musicEnabled) ? musicOn : musicOff);
            SoundController.Instance.ToggleMusic(musicEnabled);
        }
    }

    public bool Sound
    {
        get => soundEnabled;
        set
        {
            soundEnabled = value;
            soundBtn.ChangeBackgroundImage((soundEnabled) ? soundOn : soundOff);
            SoundController.Instance.ToggleSound(soundEnabled);
        }
    }

    private void OnEnable()
    {
        musicEnabled = PlayerPrefs.GetInt("music", 1) == 1;
        soundEnabled = PlayerPrefs.GetInt("sound", 1) == 1;

        musicBtn.Enable();
        soundBtn.Enable();

        musicBtn.ChangeBackgroundImage((musicEnabled) ? musicOn : musicOff);
        soundBtn.ChangeBackgroundImage((soundEnabled) ? soundOn : soundOff);
    }

    public void ToggleMusic() { Music = !Music; }
    public void ToggleSound() { Sound = !Sound; }
}
