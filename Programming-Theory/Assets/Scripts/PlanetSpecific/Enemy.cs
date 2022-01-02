using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    protected Animator enemyAnim;
    protected Transform player;

    //Patroling
    public Vector3 walkPoint;
    protected bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    protected bool alreadyAttacked;
    public GameObject projectile, fireOffset;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, dying;

    private void Awake()
    {
        player = GameObject.Find("PlayerArmature").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!dying)
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }
    }

    protected virtual void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    protected void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    protected virtual void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    protected virtual void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            Rigidbody rb = Instantiate(projectile, fireOffset.transform.position, fireOffset.transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    protected void ResetAttack()
    {
        alreadyAttacked = false;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            TakeDamage(30);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            dying = true;
            Die();
        }

    }

    protected virtual void Die()
    {
        agent.SetDestination(transform.position);
        Invoke(nameof(DestroyEnemy), 2f);
    }

    protected void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //Visualize the attack and sight range
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}