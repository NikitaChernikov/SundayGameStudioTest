using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] [Range(0.01f, 0.5f)] private float _mouseSense = 1;
    [SerializeField] [Range(-20, -10)] private int _lookUpRestriction = -15;
    [SerializeField] [Range(15, 25)] private int _lookDownRestriction = 20;

    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.position.x >= Screen.width / 2)
            {
                float rotateX = touch.deltaPosition.x * _mouseSense;
                float rotateY = touch.deltaPosition.y * _mouseSense;

                Vector3 rotCamera = transform.rotation.eulerAngles;
                Vector3 rotPlayer = _player.transform.rotation.eulerAngles;

                rotCamera.x -= rotateY;
                rotCamera.x = (rotCamera.x > 180) ? rotCamera.x - 360 : rotCamera.x;
                rotCamera.x = Mathf.Clamp(rotCamera.x, _lookUpRestriction, _lookDownRestriction);
                
                rotPlayer.y += rotateX;

                transform.rotation = Quaternion.Euler(rotCamera);
                _player.transform.rotation = Quaternion.Euler(rotPlayer);
            }
        }
    }
}