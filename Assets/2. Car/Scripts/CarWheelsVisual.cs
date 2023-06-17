using UnityEngine;

[RequireComponent(typeof(CarMovement))]
public class CarWheelsVisual : MonoBehaviour
{
    private CarMovement _carMovement;

    private void Awake()
    {
        _carMovement = GetComponent<CarMovement>();
    }

    private void OnEnable()
    {
        _carMovement.OnChangeVisualWheels += CarMovement_OnChangeVisualWheels;
    }

    private void OnDisable()
    {
        _carMovement.OnChangeVisualWheels -= CarMovement_OnChangeVisualWheels;
    }

    private void CarMovement_OnChangeVisualWheels(object sender, OnChangeVisualWheelsEventArgs e)
    {
        ChangeWheelsVisual(e.LeftWheel);
        ChangeWheelsVisual(e.RightWheel);
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
        visualWheel.transform.position = Vector3.Lerp(visualWheel.transform.position, position, 0.1f);
        visualWheel.transform.rotation = Quaternion.Lerp(visualWheel.transform.rotation, rotation, 0.1f);

    }
}
