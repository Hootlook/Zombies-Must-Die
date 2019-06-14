/************************************
 *  Class made by Jan VERMEULEN 
 ************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    PlayerMovement player;
    Transform target;
    float range;
    Animator animator;
    NavMeshAgent agent;

    //Life
    public float Life;
    public float Legs { get; set; }
    public float Armor { get; set; }
    private bool Damaged;
    private bool Dead = false;

    //Movement
    public float Speed { get; set; }
    private bool Legs_Down()
    {
        if (Legs <= 0)
        {
            return true;
        }
        return false;
    }


    //Attack
    private bool Attacking;
    public float AttackDamages { get; set; }
    private float AttackRate = 2.2f;
    private float NextAttack  = 0;
    private int MinDist = 1;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Animator
        animator = GetComponent<Animator>();
        animator.SetInteger("Random_Position", Random.Range(1, 3));
        //Stats
        Life = Random.Range(500, 2000);
        AttackDamages = Random.Range(50, 200);
        Armor = Random.Range(1, 3);
        Legs = Random.Range(100, 400);
    }

    // Update is called once per frame
    void Update()
    {
        Speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude;
        AnimatorMovementLayer();
        animator.SetFloat("Life", Life);
        animator.SetFloat("Speed", Speed);
        if (target)
        {
            range = Vector3.Distance(transform.position, target.position);
            agent.SetDestination(target.position);
            if (range < 1 && animator.GetFloat("Speed") == 0)
            {
                Attacking = true;
            }
            if (target && range > 1)
            {
                Attacking = false;
            }
        }

        if(Attacking == true && range < MinDist)
        {
            Attack();
        }


    }

    public void TakeDamage(float damage)
    {
        Damaged = true;
        animator.SetBool("Damaged", true);
        StartCoroutine(DamagedCoroutine());
        damage = damage / Armor;
        Life -= damage;
    }



    //Animations
    public void AnimatorMovementLayer()
    {
        if (Speed <= 0 && Life > 0)
        {
            IsNotMoving();
        }
        if (Speed > 0 && Life > 0)
        {
            IsMoving();
        }
        if (Life <= 0)
        {
            Dead = true;
            IsDying();
            GameObject.Destroy(gameObject, 15f);
        }
        if (Attacking)
        {
            IsAttacking();
        }
        if (Damaged)
        {
            DamagedCoroutine();
        }
    }

    private void IsNotMoving()
    {
        animator.SetBool("Idle", true);
        animator.SetLayerWeight(1, 0f);
    }
    private void IsMoving()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetBool("Legs_Down", Legs_Down());
        animator.SetBool("Idle", false);
    }
    private void IsAttacking()
    {
        animator.SetBool("Attacking", Attacking);
    }
    private void IsDying()
    {
        animator.SetBool("Dead", Dead);
        animator.SetLayerWeight(4, 1);
        agent.speed = 0;
    }



    IEnumerator DamagedCoroutine()
    {
        if (!Legs_Down())
        {
            animator.SetLayerWeight(3, 0.4f);
        }
        yield return new WaitForSeconds(2.4f);

        animator.SetBool("Damaged", false);
        animator.SetLayerWeight(3, 0);
    }

    IEnumerator Cooldown(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
    }

    private void Attack()
    {
        if (Time.time > NextAttack && range < MinDist)
        {
            NextAttack = Time.time + AttackRate;
            player.TakeDamage(100);
            StartCoroutine(Cooldown(1f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Life > 0 && other.tag == "Player")
        {
            target = other.transform;
            player = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Life > 0 && target != null)
        {
            transform.LookAt(target);
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        if (target != null && range > 0)
        {
            if (Life > 0 && range > MinDist)
            {
                animator.SetLayerWeight(2, 0);
            }
            if (Life > 0 && range < MinDist)
            {
                animator.SetLayerWeight(2, 1);
            }
        }
    }
}


