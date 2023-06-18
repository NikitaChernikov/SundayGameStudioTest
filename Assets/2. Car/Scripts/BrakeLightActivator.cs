using UnityEngine;

public class BrakeLightActivator : MonoBehaviour
{
    [SerializeField] private Light _leftLight;
    [SerializeField] private Light _rightLight;


    public void TurnLightsOn()
    {
        _leftLight.enabled = true;
        _rightLight.enabled = true;
    }

    public void TurnLightsOff()
    {
        _leftLight.enabled = false;
        _rightLight.enabled = false;
    }
}
