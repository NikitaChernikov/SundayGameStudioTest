using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static string IS_RUN_ANIMATOR_PARAMETER = "isRun";

    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerMovement _player;

    private void OnEnable()
    {
        _player.OnStartMovingAnimation += Player_OnStartMovingAnimation;
        _player.OnStartIdleAnimation += Player_OnStartIdleAnimation;
    }

    private void OnDisable()
    {
        _player.OnStartMovingAnimation -= Player_OnStartMovingAnimation;
        _player.OnStartIdleAnimation -= Player_OnStartIdleAnimation;
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
