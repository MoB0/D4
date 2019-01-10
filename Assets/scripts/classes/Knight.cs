using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public int WalkSpeed;
    public int Str;
    public int Dex;
    public int Intelligence;
    public int AttackSpeed;
    public int Stamina;
    public float MeleeRange;
    public float RangedRange;

    void Awake()
    {
        WalkSpeed = 6;
        Str = 9;
        Dex = 3;
        Intelligence = 3;
        AttackSpeed = 6;
        Stamina = 6;
        MeleeRange=3;
        RangedRange=10;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
