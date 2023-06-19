using UnityEngine;

public class GroundChekcer : MonoBehaviour
{
    private bool _isGrounded;

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void Update()
    {
        Debug.Log(_isGrounded);
    }

    public bool IsGrounded()
    {
        return _isGrounded;
    }
}
