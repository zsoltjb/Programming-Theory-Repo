using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcEnemy : Enemy
{
    private void AnimationMovement(string todo)
    {
        enemyAnim.SetBool("patroling", (todo == "patrol"));
        enemyAnim.SetBool("chasing", (todo == "chase"));
        enemyAnim.SetBool("attacking", (todo == "attack"));
        enemyAnim.SetBool("die", (todo == "die"));
        Debug.Log(todo);
    }
    
    protected override void Patroling()
    {
        AnimationMovement("patrol");
        base.Patroling();
    }

    protected override void ChasePlayer()
    {
        AnimationMovement("chase");
        base.ChasePlayer();
    }

    protected override void AttackPlayer()
    {
        AnimationMovement("attack");
        base.AttackPlayer();
    }

    protected override void Die()
    {
            AnimationMovement("die");
            Invoke(nameof(DestroyEnemy), 10f);
    }
}
