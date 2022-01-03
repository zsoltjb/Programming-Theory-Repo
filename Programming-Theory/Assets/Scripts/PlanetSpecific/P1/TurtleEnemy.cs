using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class TurtleEnemy : Enemy
{
    //POLYMORPHISM
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

    //POLYMORHPISM
    protected override void Die()
    {
            //AnimationMovement("die");
            Invoke(nameof(DestroyEnemy), 10f);
    }
}
