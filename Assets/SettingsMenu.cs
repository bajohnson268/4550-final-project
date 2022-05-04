using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Controller to set the volume in the game,
    // using an exposed parameter.
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }
}
