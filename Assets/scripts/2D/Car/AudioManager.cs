using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb3d.CommonLogic.Sound
{
    public class AudioManager : MonoBehaviour
    { 
        [SerializeField]
        private Car2d _player;

        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();

            if(_player==null)
                _player = Car2d.Instance;
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
}