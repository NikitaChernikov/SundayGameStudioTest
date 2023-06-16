using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private AxleInfo[] axleInfos;
    [SerializeField] private float _maxMotorTorque;
    [SerializeField] private float _maxSteeringAngle;

    private void FixedUpdate()
    {
        float motor = _maxMotorTorque * joystick.Vertical; //���������
        float steering = _maxSteeringAngle * joystick.Horizontal; //���� ��������
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.isSteering)
            {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.isConnectedToMotor)
            {
                axleInfo.LeftWheel.motorTorque = motor; //����� � ����������� �� ��������� ��������� �������� - ��� +
                axleInfo.RightWheel.motorTorque = motor;  //����� � ����������� �� ��������� ��������� �������� - ��� +              
            }
        }
    }
}
