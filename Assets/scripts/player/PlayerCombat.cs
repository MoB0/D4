using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Ray AttackRay;
    RaycastHit AttackHit;
    int attackMask;
    private float MeleeRange;
    private float RangedRange;


    private void Awake()
    {
        attackMask = LayerMask.GetMask("attackMask");
        MeleeRange = GetComponent<PlayerAttributes>().MeleeRange;
        RangedRange = GetComponent<PlayerAttributes>().RangedRange;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Attack(Vector3 attackDir)
    {
        AttackRay.origin = transform.position;
        AttackRay.direction = attackDir;
        if (Physics.Raycast(AttackRay, out AttackHit, MeleeRange , attackMask))
        {

        }
    }
}
