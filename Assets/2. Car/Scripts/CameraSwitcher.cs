using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;

    private int _cameraIndex = 0;

    public void SwitchCamera()
    {
        _cameras[_cameraIndex].enabled = false;
        _cameraIndex++;

        if (_cameraIndex >= _cameras.Length)
        {
            _cameraIndex = 0;
        }

        _cameras[_cameraIndex].enabled = true;
    }
}
