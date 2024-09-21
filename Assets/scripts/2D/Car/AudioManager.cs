using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _audio;

    Car2d _player;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("CarBody").GetComponent<Car2d>();
    }

    private void FixedUpdate()
    {
        AudioClip clip = _player.TakeCorrectAudioClip();
        if (_audio.clip != clip)
        {
            _audio.clip = clip;
            _audio.Play();
        }

    }
}
