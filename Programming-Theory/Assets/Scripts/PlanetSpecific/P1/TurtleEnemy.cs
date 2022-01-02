using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : Enemy
{

    protected override void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    protected override void Die()
    {
            //AnimationMovement("die");
            Invoke(nameof(DestroyEnemy), 10f);
    }
}
