using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using Slider = UnityEngine.UI.Slider;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string volumeValueAccessor;
    [SerializeField] private float2 minMaxDecibels;
    [SerializeField] private Slider slider;

    private void Start()
    {
        SetMixerVolume(slider.value);
        slider.onValueChanged.AddListener(SetMixerVolume);
    }

    public void SetMixerVolume(float targetVolume)
    {
        Debug.Log("aaa");
        audioMixer.SetFloat(volumeValueAccessor, Mathf.Lerp(minMaxDecibels.x, minMaxDecibels.y, targetVolume));
    }

}
