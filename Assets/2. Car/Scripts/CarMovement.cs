using System;
using UnityEngine;

[RequireComponent(typeof(CarInputHandler))]
public class CarMovement : MonoBehaviour
{
    [SerializeField] private AxleInfo[] axleInfos;
    [SerializeField] private float _maxMotorTorque;
    [SerializeField] private float _maxSteeringAngle;
    [SerializeField] private float _breakForce = 10000;

    [SerializeField] private Vector3 _carCenterOfMass = new Vector3(0, 0, 0);

    private CarInputHandler _carInput;
    private Rigidbody _rb;

    private void Awake()
    {
        _carInput = GetComponent<CarInputHandler>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.centerOfMass = _carCenterOfMass;
    }

    private void FixedUpdate()
    {
        float motor = _maxMotorTorque * _carInput.GetVerticalInput(); 
        float steering = _maxSteeringAngle * _carInput.GetHorizontalInput(); 
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.isSteering)
            {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.isConnectedToMotor)
            {
                axleInfo.LeftWheel.motorTorque = motor; //здесь в зависимости от локальных координат выбираем - или +
                axleInfo.RightWheel.motorTorque = motor;  //здесь в зависимости от локальных координат выбираем - или +              
            }
            if (_carInput.GetBreakState())
            {
                axleInfo.LeftWheel.brakeTorque = _breakForce;
                axleInfo.RightWheel.brakeTorque = _breakForce;
            }
            else
            {
                axleInfo.LeftWheel.brakeTorque = 0;
                axleInfo.RightWheel.brakeTorque = 0;
            }
            ChangeWheelsVisual(axleInfo.LeftWheel);
            ChangeWheelsVisual(axleInfo.RightWheel);
        }
    }

    private void ChangeWheelsVisual(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = Vector3.Lerp(visualWheel.transform.position,position, 0.1f);
        visualWheel.transform.rotation = Quaternion.Lerp(visualWheel.transform.rotation, rotation, 0.1f);

    }
}
