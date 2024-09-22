using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistantLabel : MonoBehaviour
{
    private Transform _player, _finish;

    private Vector3 _start;

    public float _metersCounter = 0;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("CarBody").GetComponent<Transform>();

        _start = _player.transform.position;

        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();

        LableHandler.Instance.DistancesSlider.maxValue = Vector3.Distance(_player.position, _finish.position);

    }

    private void FixedUpdate()
    {
        _metersCounter += Mathf.Abs(Vector3.Distance(_start, _player.position) - LableHandler.Instance.DistancesSlider.value);

        LableHandler.Instance.UpdateDistance(Vector3.Distance(_player.position, _finish.position), Vector3.Distance(_start, _player.position));
    }
}
