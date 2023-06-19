using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static string IS_RUN_ANIMATOR_PARAMETER = "isRun";
    private static string JUMP_ANIMATOR_PARAMETER = "Jump";
    private static string SHOOT_ANIMATOR_PARAMETER = "isShoot";
    private static string RUN_AND_SHOOT_PARAMETER = "RunAndShoot";

    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private PlayerShoot _playerShoot;

    private float _runAndShootValue = 0.5f;
    private float _shootValue = 0;
    private bool _isRunning = false;

    private void OnEnable()
    {
        _player.OnMove += Player_OnStartMovingAnimation;
        _player.OnJumped += GroundChecker_OnJumped;
        _playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void OnDisable()
    {
        _player.OnMove -= Player_OnStartMovingAnimation;
        _player.OnJumped -= GroundChecker_OnJumped;
        _playerShoot.OnShoot -= PlayerShoot_OnShoot;
    }

    private void PlayerShoot_OnShoot(object sender, OnShootEventArgs e)
    {
        _anim.SetBool(SHOOT_ANIMATOR_PARAMETER, e.IsShooting);
        if (_isRunning)
        {
            _anim.SetFloat(RUN_AND_SHOOT_PARAMETER, _runAndShootValue);
        }
        else
        {
            _anim.SetFloat(RUN_AND_SHOOT_PARAMETER, _shootValue);
        }
    }

    private void GroundChecker_OnJumped(object sender, System.EventArgs e)
    {
        _anim.SetTrigger(JUMP_ANIMATOR_PARAMETER);
    }

    private void Player_OnStartMovingAnimation(object sender, OnMoveEventArgs e)
    {
        _anim.SetBool(IS_RUN_ANIMATOR_PARAMETER, e.IsMoving);
        _isRunning = e.IsMoving;
    }
}
