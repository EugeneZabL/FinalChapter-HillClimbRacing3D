using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2d : MonoBehaviour
{
    public PlayerStats PlayerStat;

    [SerializeField]
    private Transform _model;

    [SerializeField]
    WheelJoint2D _backWheel, _frontWheel;

    [SerializeField]
    Transform _pointToRotate;

    [SerializeField]
    Rigidbody2D _carBody;

    float _maxSpeed;

    public bool GasIsPressed = false;
    public bool BreakIsPressed = false;

    private float _amountOfFuel;
    public float AmountOfFuel { get { return _amountOfFuel; } set { _amountOfFuel = value > 100 ? 100 : value; } }

    JointMotor2D _motor;

    float _speed;


    float _speedMult;
    float _fuelMult;

    private void Start()
    {

        AmountOfFuel = 100;

        StartCoroutine(FuelController());

        _speedMult = PlayerStat.CalculateSpeedMultiplier();
        _fuelMult = PlayerStat.CalculateFuelMultiplier();

        _maxSpeed = 1000f * _speedMult * 1.5f;

        _motor.maxMotorTorque = _maxSpeed;

        PlayerStat.CarType.TakeCarModel(_model);
    }

    private void Update()
    {
        //MoveControllByKey();


        if (BreakIsPressed)
            BreakeCar();
        else if (GasIsPressed)
            GasCar();

        if (_speed > 0)
            _speed -= 1000f * Time.deltaTime * _speedMult;

        _motor.motorSpeed = -_speed;
        _backWheel.motor = _motor;
    }
    private void FixedUpdate()
    {
        LableHandler.Instance.UpdateFuel(_amountOfFuel);
    }

    void GasCar()
    {
        if (_speed < 0)
            _speed = 0;
        else if (_speed <= _maxSpeed)
            _speed += 1500f * Time.deltaTime * _speedMult;

        _carBody.AddTorque(1500F * Time.deltaTime * _speedMult);
    }

    void BreakeCar()
    {
        if (_speed >= -_maxSpeed / 5)
            _speed -= 1000f * Time.deltaTime * _speedMult;

        _carBody.AddTorque(-2500F * Time.deltaTime * _speedMult);
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

    public AudioClip TakeCorrectAudioClip()
    {
        return PlayerStat.CarType.TakeAClip(_speed, _maxSpeed, GasIsPressed || BreakIsPressed);
    }

    IEnumerator FuelController()
    {
        while (true)
        {

            if (GasIsPressed)
                AmountOfFuel -= 1 * Time.deltaTime * _fuelMult;
            else if (BreakIsPressed)
                AmountOfFuel -= 0.5f * Time.deltaTime * _fuelMult;

            if (AmountOfFuel <= 0)
            {
                StopGame(false);
                yield break;
            }


            yield return null;
        }
    }

    public void StopGame(bool isWin)
    {
        GasIsPressed = false;
        BreakIsPressed = false;

        foreach (ParticleSystem partic in GetComponentsInChildren<ParticleSystem>())
            partic.Stop();

        GetComponent<ScoreManager>().EndGame(isWin);
    }

}
