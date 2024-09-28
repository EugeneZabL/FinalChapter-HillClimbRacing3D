using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb3d.CommonLogic
{
    public class Car2d : MonoBehaviour
    {
        public static Car2d Instance { get; private set; }

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

        ParticleSystem[] _particls;

        JointMotor2D _motor;

        float _speed, _speedMult, _fuelMult;

        const float FRICTION = 1000f;

        const float GUS_BASE = 1500f;
        const float GUS_BASE_ROTATE = 1500f;

        const float BREAK_BASE = 1000f;
        const float BREAK_BASE_ROTATE = 2500f;

        const float BREAK_MAX_SPEED_MULT = 0.3F;
        const float GUS_MAX_SPEED_MULT = 1.5F;



        private void Awake()
        {
            Instance = this;

            AmountOfFuel = 100;

            StartCoroutine(FuelController());

            _speedMult = PlayerStat.CalculateSpeedMultiplier();
            _fuelMult = PlayerStat.CalculateFuelMultiplier();

            _maxSpeed = FRICTION * _speedMult * GUS_MAX_SPEED_MULT;

            _motor.maxMotorTorque = _maxSpeed;

            PlayerStat.CarType.TakeCarModel(_model);

            _particls = GetComponentsInChildren<ParticleSystem>();
        }

        private void Update()
        {
            //MoveControllByKey();


            if (BreakIsPressed)
                BreakeCar();
            else if (GasIsPressed)
                GasCar();

            if (_speed > 0)
                _speed -= FRICTION * Time.deltaTime * _speedMult;

            _motor.motorSpeed = -_speed;
            _backWheel.motor = _motor;

            UpdateParticle();

        }

        void UpdateParticle()
        {
            if (GasIsPressed && _particls[0].isStopped)
                foreach (ParticleSystem particle in _particls)
                    particle.Play();
            else if (!GasIsPressed && _particls[0].isPlaying)
                foreach (ParticleSystem particle in _particls)
                    particle.Stop();
        }

        void GasCar()
        {
            if (_speed < 0)
                _speed = 0;
            else if (_speed <= _maxSpeed)
                _speed += GUS_BASE * Time.deltaTime * _speedMult;

            _carBody.AddTorque(GUS_BASE_ROTATE * Time.deltaTime * _speedMult);
        }

        void BreakeCar()
        {
            if (_speed >= -_maxSpeed * BREAK_MAX_SPEED_MULT)
                _speed -= BREAK_BASE * Time.deltaTime * _speedMult;

            _carBody.AddTorque(-BREAK_BASE_ROTATE * Time.deltaTime * _speedMult);
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
}
