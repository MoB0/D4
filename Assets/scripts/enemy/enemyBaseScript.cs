using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBaseScript : MonoBehaviour
{
    public float speed;
    public float meleeRange;
    public float detectRange;
    public float patrolRange;

    float patrolTimer;
    float lastPatrolChange;
    public Transform patrolTarget;
    Vector3 modifiedTarget;
    float stopTimer;


    [SerializeField]
    bool patrol;

    public CharacterController controller;
    public Transform player;

    Animator anim;
    public AnimationClip run;
    public AnimationClip idle;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        patrolTimer = Random.Range(1f, 2.5f);                   //time for patrol movement
        stopTimer = Random.Range(0f, 2.5f);                     //time for patrol movement stop between directions
        patrolTarget.position = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        lastPatrolChange = Time.time;
        Debug.Log(patrolTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        checkRange();
    }

    bool inMeleeRange()
    {
        if (Vector3.Distance(transform.position, player.position) < meleeRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void checkRange()
    {
        if (Vector3.Distance(transform.position, player.position) < detectRange)            //check if player is in detecting range
        {
            Debug.Log("chasing");
            transform.LookAt(player.position);                                              //turn enemy towards player
            controller.SimpleMove(transform.forward * speed);                               //move enemy towards player
            //anim.Play("run");
        }
        if (patrol == true)
        {
            if (Vector3.Distance(transform.position, player.position) < patrolRange && Vector3.Distance(transform.position, player.position) > detectRange)            //check if player is in patrolling range but not in detecting range
            {
                Patrol();
            }
            
        }
    }

    void Patrol()
    {
        if (Time.time < lastPatrolChange + patrolTimer)
        {
            //Debug.Log(transform.forward);
                                                                                            //turn enemy towards patrolDirection
            controller.SimpleMove(transform.forward * speed);                               //move enemy towards patrolDirection
        }
        else if (Time.time > lastPatrolChange + patrolTimer+stopTimer)
        {
            patrolTimer = Random.Range(1f, 2.5f);
            modifiedTarget = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            modifiedTarget.y = transform.position.y;
            patrolTarget.position = modifiedTarget;
            lastPatrolChange = Time.time;
            Debug.Log("new values");
            Debug.Log(patrolTimer);
            Debug.Log(patrolTarget.position);
            
            transform.LookAt(patrolTarget);
        }
    }
}
