using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//https://www.youtube.com/watch?time_continue=368&v=OYwQFpJIFGg

public class playerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving;

    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private Transform targetedEnemy;
    private Ray shootRay;
    private RaycastHit shootHit;
    private bool walking;
    private bool enemyClicked;
    private float nextFire;

    public float MeleeRange;
    public float RangedRange;
    public float AttackRate;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
        MeleeRange = GetComponent<PlayerAttributes>().MeleeRange;
        RangedRange = GetComponent<PlayerAttributes>().RangedRange;
        AttackRate = GetComponent<PlayerAttributes>().AttackRate;
        navMeshAgent.speed = GetComponent<PlayerAttributes>().WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.Resume();
                }
            }            
        }

        if (enemyClicked)
        {
            MoveAndAttack();
        }
        if (navMeshAgent.remainingDistance <= MeleeRange)//navMeshAgent.stoppingDistance)
        {
            walking = false;
            navMeshAgent.Stop();
        }
        else
        {
            walking = true;
        }
        //anim.SetBool("IsWalking", walking);
    }

    void MoveAndAttack()
    {
        if (targetedEnemy == null)
        {
            return;
        }
        navMeshAgent.destination = targetedEnemy.position;
        if(navMeshAgent.remainingDistance >= MeleeRange)
        {
            navMeshAgent.Resume();
            walking = true;
        }
        if (navMeshAgent.remainingDistance <= MeleeRange)
        {
            transform.LookAt(targetedEnemy);
            Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;
            if(Time.time > nextFire)
            {
                nextFire = Time.time + AttackRate;
                GetComponent<PlayerCombat>().Attack(dirToAttack);
            }
            navMeshAgent.Stop();
            walking = false;
        }

    }

}
