using System;
using UnityEngine;

[RequireComponent(typeof(CarInputHandler))]
public class CarMovement : MonoBehaviour
{
    public event EventHandler<OnChangeVisualWheelsEventArgs> OnChangeVisualWheels;

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
            OnChangeVisualWheels?.Invoke(this, new OnChangeVisualWheelsEventArgs
            {
                LeftWheel = axleInfo.LeftWheel,
                RightWheel = axleInfo.RightWheel
            });
            //ChangeWheelsVisual(axleInfo.LeftWheel);
            //ChangeWheelsVisual(axleInfo.RightWheel);
        }
    }
}

public class OnChangeVisualWheelsEventArgs : EventArgs
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
}