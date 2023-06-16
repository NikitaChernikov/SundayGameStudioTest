using UnityEngine;

[System.Serializable]
public class AxleInfo 
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool isConnectedToMotor; 
    public bool isSteering; 
}
