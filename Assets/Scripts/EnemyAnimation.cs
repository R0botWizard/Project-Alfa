using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Enemy _enemyController;
    [SerializeField] private AnimationClip _atackAnimation;

    private void Start()
    {
        _enemyAnimator = GetComponentInChildren<Animator>();
        _enemyController.SetAtackTime(_atackAnimation.length);
    }
    void Update()
    {
        setAnimation();
    }

    private void setAnimation()
    {
        if (_enemyController.isChasing)
        {
            _enemyAnimator.SetBool("isChasing",true);
            if (_enemyController.isAtacking)
            {
                _enemyAnimator.SetBool("isAtacking", true);
            }
            else
            {
                _enemyAnimator.SetBool("isAtacking", false);
            }
        }
        else
        {
            _enemyAnimator.SetBool("isChasing", false);
        }
    }

}
