using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerController _playerController;

    void Update()
    {
        setMoveAnimation();
    }

    private void setMoveAnimation()
    {
        int multiplier = 1;
        if (_playerController.isSprinting)
        {
            multiplier = 2;
        }
        _playerAnimator.SetFloat("VelocityX", _playerController.dir.x * multiplier);
        _playerAnimator.SetFloat("VelocityZ", _playerController.dir.z * multiplier);
    }
}
