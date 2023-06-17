using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    private int _verticalInput;
    private int _horizontalInput;
    private bool _isBreak;

    public void SetVerticalInput(int moveInput)
    {
        _verticalInput = moveInput;
    }

    public void SetHorizontalInput(int moveInput)
    {
        _horizontalInput = moveInput;
    }

    public void SetBreakState(bool isBreak)
    {
        _isBreak = isBreak;
    }

    public int GetVerticalInput()
    {
        return _verticalInput;
    }

    public int GetHorizontalInput()
    {
        return _horizontalInput;
    }

    public bool GetBreakState()
    {
        return _isBreak;
    }
    
}
