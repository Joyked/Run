using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReturnSoundEffect : MonoBehaviour
{
    [SerializeField] private float _delay;
    
    private AudioSource _audio;

    private void Awake() =>
        _audio = GetComponent<AudioSource>();

    private void OnEnable() =>
        _audio.PlayDelayed(_delay);
}
