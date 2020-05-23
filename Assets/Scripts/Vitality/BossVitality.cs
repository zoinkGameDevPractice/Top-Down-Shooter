using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVitality : Vitality
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if(currentHealth <= maxHealth/2)
        {
            animator.SetTrigger("secondPhase");
        }
    }

    public override void Die()
    {
        base.Die();
        animator.SetTrigger("die");
    }
}
