using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance { get; private set; }

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private Image _backGround;

    [SerializeField]
    float _audioVolume = 0.4f;

    [SerializeField]
    List<AudioClip> _audioClips;

    private void Start()
    {
        Instance = this;
        AudioSource _audio = GetComponent<AudioSource>();
        _audio.clip = _audioClips[Random.Range(0, _audioClips.Count)];
        _audio.Play();


        Tween.LocalPositionY(_backGround.transform, -Screen.height, 0.5f, Ease.InExpo, startDelay: 0.2f).OnComplete(() => _canvas.enabled = false) ;
        Tween.AudioVolume(_audio,_audioVolume,1f);
    }

    public void ChangeScreen(string _sceneName)
    {
        _canvas.enabled = true;
        Tween.LocalPositionY(_backGround.transform, 0, 0.5f, Ease.InExpo).OnComplete(()=>SceneManager.LoadScene(_sceneName));
        Tween.AudioVolume(GetComponent<AudioSource>(), 0, 0.5f);
    }

}
