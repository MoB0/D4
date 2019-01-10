using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public int WalkSpeed;
    public int Str;
    public int Dex;
    public int Intelligence;
    public int AttackSpeed;
    public int Stamina;
    public float MeleeRange;
    public float RangedRange;

    // Start is called before the first frame update
    void Start()
    {
        WalkSpeed = 9;
        Str = 3;
        Dex = 3;
        Intelligence = 9;
        AttackSpeed = 6;
        Stamina = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
