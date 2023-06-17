using UnityEngine;

public class BrakeTrailActivator : MonoBehaviour
{
    [SerializeField] TrailRenderer leftWheel;
    [SerializeField] TrailRenderer rightWheel;

    public void ActivateTrail()
    {
        leftWheel.emitting = true;
        rightWheel.emitting = true;
    }

    public void DeactivateTrail()
    {
        leftWheel.emitting = false;
        rightWheel.emitting = false;
    }
}
