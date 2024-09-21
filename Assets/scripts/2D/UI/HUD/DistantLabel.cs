using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistantLabel : MonoBehaviour
{
    private Transform _player, _finish;

    private Vector3 _start;

    private float _roadDistance;

    private Slider _slider;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("CarBody").GetComponent<Transform>();

        _start = _player.transform.position;
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();

        _roadDistance = Vector3.Distance(_player.position, _finish.position);


        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = _roadDistance;

        _text = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void FixedUpdate()
    {
        _text.text = Vector3.Distance(_player.position, _finish.position).ToString("F0");

        _slider.value = Vector3.Distance(_start, _player.position);
    }
}
