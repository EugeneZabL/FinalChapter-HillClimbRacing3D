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
    public bool BreakIsPressed = false;

    public float AmountOfFuel;

    JointMotor2D _motor;

    float _speed;



    private void Start()
    {
        _motor.maxMotorTorque = 5000;
        AmountOfFuel = 100;

        StartCoroutine(FuelController());
    }

    private void Update()
    {
        //MoveControllByKey();

        if (BreakIsPressed)
            BreakeCar();
        else if (GasIsPressed)
            GasCar();

        if (_speed > 0)
            _speed -= 1000f * Time.deltaTime;

        _motor.motorSpeed = -_speed;
        _backWheel.motor = _motor;
    }

    void GasCar()
    {
        if (_speed < 0)
            _speed = 0;
        else if (_speed <= _maxSpeed)
            _speed += 1500f * Time.deltaTime;

        _carBody.AddTorque(1500F * Time.deltaTime);
    }

    void BreakeCar()
    {
        if (_speed >= -_maxSpeed / 5)
            _speed -= 1000f * Time.deltaTime;

        _carBody.AddTorque(-2500F * Time.deltaTime);
    }

    void MoveControllByKey()
    {
        if (Input.GetKey(KeyCode.W))
            GasIsPressed = true;
        else
            GasIsPressed = false;

        if (Input.GetKey(KeyCode.S))
            BreakIsPressed = true;
        else
            BreakIsPressed = false;
    }

    IEnumerator FuelController()
    {
        while (true)
        {

            if (GasIsPressed)
                AmountOfFuel -= 1 * Time.deltaTime;
            else if(BreakIsPressed)
                AmountOfFuel -= 0.5f * Time.deltaTime;

            if(AmountOfFuel<=0)
                Debug.Log("GG");

            yield return null;
        }
    }



}
