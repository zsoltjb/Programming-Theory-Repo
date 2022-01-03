using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class OrcEnemy : Enemy
{
    //ABSTRACTION
    private void AnimationMovement(string todo)
    {
        enemyAnim.SetBool("patroling", (todo == "patrol"));
        enemyAnim.SetBool("chasing", (todo == "chase"));
        enemyAnim.SetBool("attacking", (todo == "attack"));
        enemyAnim.SetBool("die", (todo == "die"));
        Debug.Log(todo);
    }
    //POLYMORHPISM
    protected override void Patroling()
    {
        AnimationMovement("patrol");
        base.Patroling();
    }
    //POLYMORHPISM
    protected override void ChasePlayer()
    {
        AnimationMovement("chase");
        base.ChasePlayer();
    }
    //POLYMORHPISM
    protected override void AttackPlayer()
    {
        AnimationMovement("attack");
        base.AttackPlayer();
    }
    //POLYMORHPISM
    protected override void Die()
    {
            AnimationMovement("die");
            Invoke(nameof(DestroyEnemy), 10f);
    }
}
