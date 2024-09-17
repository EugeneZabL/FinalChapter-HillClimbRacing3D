using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private string _nameFun;

    private bool _isEnable = true;

    private Car2d _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Car2d>();
    }

    public void ButtonPressed()
    {
        ;
    }
}
