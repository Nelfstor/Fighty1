using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void Killed(EnemyController sender);
public class EnemyController : MonoBehaviour
{
    public event Killed killed;

    private Animator animator;

    bool isAlive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            Global.Log.MyCyanLog("Hit!");
            // Animation Dead
            AnimateDeath();
            isAlive = false;
            killed.Invoke(this);
        }
    }

    private void AnimateDeath()
    {
        animator.SetBool("isDead", true);
    }
}
