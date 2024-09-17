using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerOk : MonoBehaviour
{
    public WheelCollider frontRightWheels;
    public WheelCollider frontLeftWheels;// Один коллайдер для передних колёс
    public WheelCollider BackRightWheels;
    public WheelCollider BackLeftWheels;


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

    private void Update()
    {
        motorInput = Input.GetAxis("Vertical") * motorForce;

        //rearWheels.motorTorque = motorInput;

        if (_rbCar.velocity.magnitude < MaxSpeed || motorInput<0)
        {
            BackRightWheels.motorTorque = motorInput;
            BackLeftWheels.motorTorque = motorInput;
        }
        else
        {
            BackRightWheels.motorTorque = 0;
            BackLeftWheels.motorTorque = 0;  // Отключаем подачу силы, если достигли максимальной скорости
        }


        RotateCarInput();
       // UpdateWheels();
    }


    /*
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
    */

    void RotateCarInput()
    { 
            
        _rbCar.AddForceAtPosition(_pointToRotate.forward * 400 * Input.GetAxis("Vertical"), _pointToRotate.position);
        if (!frontRightWheels.GetGroundHit(out WheelHit hit))
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

}
