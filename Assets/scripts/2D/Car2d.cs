using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2d : MonoBehaviour
{
    [SerializeField]
    WheelJoint2D _backWheel, _frontWheel;

    [SerializeField]
    Transform _pointToRotate;

    [SerializeField]
    Rigidbody2D _carBody;

    [SerializeField]
    float _maxSpeed;

    public bool GasIsPressed = false;
    public bool StopIsPressed = false;

    JointMotor2D _motor;

    float _speed;

    private void Start()
    {
        _motor.maxMotorTorque = 5000;
    }

    private void Update()
    {
        MoveControllByKey();

        if (StopIsPressed)
            Stoper();
        else if (GasIsPressed)
            Gas();

        if (_speed > 0)
            _speed -= 1000f * Time.deltaTime;

        _motor.motorSpeed = _speed;
        _backWheel.motor = _motor;
    }

    void Gas()
    {
        if (_speed < 0)
            _speed = 0;
        else if (_speed <= _maxSpeed)
            _speed += 1500f * Time.deltaTime;

        _carBody.AddTorque(1500F * Time.deltaTime);
    }

    void Stoper()
    {
        if (_speed >= -_maxSpeed / 5)
            _speed -= 1000f * Time.deltaTime;

        _carBody.AddTorque(-2500F * Time.deltaTime);
    }

    void MoveControllByKey()
    {
        if(Input.GetKey(KeyCode.W))
            GasIsPressed = true;
        else
            GasIsPressed = false;

        if(Input.GetKey(KeyCode.S))
            StopIsPressed = true;
        else
            StopIsPressed=false;
    }
}
