using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontWheels;  // Один коллайдер для передних колёс
    public WheelCollider BackWheels;

    public float MaxSpeed;

    public Transform FrontWheelTransform;
    public Transform BackWheelRightTransform;


    //private Vector3 _differentWheels;

    [SerializeField]
    private Rigidbody _rbCar;
    [SerializeField]
    private Transform _pointToRotate;

    public float motorForce = 1500f;

    private float motorInput;

    private void Start()
    {
        Vector3 pos;
        Quaternion quat;

        frontWheels.GetWorldPose(out pos, out quat);
       // _differentWheels = pos - FrontWheelTransform.position;
    }
    private void Update()
    {


        motorInput = Input.GetAxis("Vertical") * motorForce;

        //rearWheels.motorTorque = motorInput;

        if (_rbCar.velocity.magnitude < MaxSpeed || motorInput<0)
        {
            BackWheels.motorTorque = motorInput;
        }
        else
        {
            BackWheels.motorTorque = 0;  // Отключаем подачу силы, если достигли максимальной скорости
        }

        RotateCarInput();

        UpdateWheels();
        PuseCheck();
    }

    private void FixedUpdate()
    {
        //ResetRotationYZ();
    }

    private void UpdateWheels()
    {
        Vector3 pos;
        Quaternion quat;

        frontWheels.GetWorldPose(out pos, out quat);
        FrontWheelTransform.position = pos ;
        FrontWheelTransform.rotation = quat;

        BackWheels.GetWorldPose(out pos, out quat);
        BackWheelRightTransform.position = pos;
        BackWheelRightTransform.rotation = quat;
    }

    void RotateCarInput()
    {
        _rbCar.AddForceAtPosition(_pointToRotate.forward * 400 * Input.GetAxis("Vertical"), _pointToRotate.position);
        if (!frontWheels.GetGroundHit(out WheelHit hit))
            _rbCar.AddForceAtPosition(_pointToRotate.forward * 250 * Input.GetAxis("Vertical"), _pointToRotate.position);
    }

    void RotateCarInputPerf()
    {
        float rotationInput = Input.GetAxis("Horizontal") * 400 * Time.deltaTime;

        // Создаем поворот
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(rotationInput, 0f, 0f));

        // Применяем вращение через MoveRotation
        _rbCar.MoveRotation(_rbCar.rotation * deltaRotation);
    }

    void PuseCheck()
    {
        if(Input.GetKeyDown(KeyCode.K))
            Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.L))
            Time.timeScale = 1;
    }

    // Метод для сброса углов по осям y и z
    public void ResetRotationYZ()
    {
        // Получаем текущие углы вращения объекта
        Vector3 currentRotation = transform.eulerAngles;

        // Сбрасываем углы по осям y и z, оставляем угол по x
        currentRotation.y = 0f;
        currentRotation.z = 0f;

        // Применяем новые значения углов к объекту
        transform.eulerAngles = currentRotation;
    }
}
