using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class CarControllButtonScript : MonoBehaviour
{

    [SerializeField]
    private int _buttonType;    // 0 - Breake
                                // 1 - Gas

    private Car2d _player;

    private Transform _transform;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("CarBody").GetComponent<Car2d>();
        _transform = transform.GetComponentInParent<Transform>();
    }

    public void ButtonPressedDown()
    {
        switch (_buttonType)
        {
            case 0:
                _player.BreakIsPressed = true;
                break;
            case 1:
                _player.GasIsPressed = true;
                break;
            default:
                Debug.Log("Control Button is not set!");
                break;
        }
        Tween.Scale(_transform, 0.7f, 0.3f, Ease.InOutBack);
    }

    public void ButtonPressedUp()
    {
        switch (_buttonType)
        {
            case 0:
                _player.BreakIsPressed = false;
                break;
            case 1:
                _player.GasIsPressed = false;
                break;
            default:
                Debug.Log("Control Button is not set!");
                break;
        }
        Tween.Scale(_transform, 1f ,0.3f,Ease.InOutBack);
    }

}
