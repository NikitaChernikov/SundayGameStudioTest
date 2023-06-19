using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static string IS_RUN_ANIMATOR_PARAMETER = "isRun";
    private static string JUMP_ANIMATOR_PARAMETER = "Jump";
    private static string SHOOT_ANIMATOR_PARAMETER = "Shoot";

    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private PlayerShoot _playerShoot;

    private void OnEnable()
    {
        _player.OnStartMoving += Player_OnStartMovingAnimation;
        _player.OnStopMoving += Player_OnStartIdleAnimation;
        _player.OnJumped += GroundChecker_OnJumped;
        _playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void OnDisable()
    {
        _player.OnStartMoving -= Player_OnStartMovingAnimation;
        _player.OnStopMoving -= Player_OnStartIdleAnimation;
        _player.OnJumped -= GroundChecker_OnJumped;
        _playerShoot.OnShoot -= PlayerShoot_OnShoot;
    }

    private void PlayerShoot_OnShoot(object sender, System.EventArgs e)
    {
        _anim.SetTrigger(SHOOT_ANIMATOR_PARAMETER);
    }

    private void GroundChecker_OnJumped(object sender, System.EventArgs e)
    {
        _anim.SetTrigger(JUMP_ANIMATOR_PARAMETER);
    }

    private void Player_OnStartIdleAnimation(object sender, System.EventArgs e)
    {
        _anim.SetBool(IS_RUN_ANIMATOR_PARAMETER, false);
    }

    private void Player_OnStartMovingAnimation(object sender, System.EventArgs e)
    {
        _anim.SetBool(IS_RUN_ANIMATOR_PARAMETER, true);
    }
}
