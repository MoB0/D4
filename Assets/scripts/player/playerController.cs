using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//https://www.youtube.com/watch?time_continue=368&v=OYwQFpJIFGg

public class playerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 modifiedTarget;
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
        anim = GetComponentInChildren<Animator>();
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
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButton(0))
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
                    modifiedTarget = hit.point;                     //save hit.point to own variable
                    modifiedTarget.y = transform.position.y;        //modify y axis so that player wont look up or down
                    transform.LookAt(modifiedTarget);               //look at modified target
                    navMeshAgent.destination = hit.point;           //set destination
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
        Debug.Log(navMeshAgent.remainingDistance);
        if (navMeshAgent.remainingDistance > MeleeRange)
        {
            walking = true;
        }
        if (navMeshAgent.remainingDistance <= MeleeRange)
        {
            navMeshAgent.velocity = Vector3.zero;
            walking = false;
            modifiedTarget = targetedEnemy.position;        //save hit.point to own variable
            modifiedTarget.y = transform.position.y;        //modify y axis so that player wont look up or down
            transform.LookAt(modifiedTarget);               //look at modified target

            Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;
            if(Time.time > nextFire)
            {
                nextFire = Time.time + AttackRate;
                GetComponent<PlayerCombat>().Attack(dirToAttack);
            }           
        }
    }
}
