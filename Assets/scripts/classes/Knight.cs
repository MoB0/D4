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

    // Start is called before the first frame update
    void Start()
    {
        WalkSpeed = 7;
        Str = 9;
        Dex = 3;
        Intelligence = 3;
        AttackSpeed = 6;
        Stamina = 6;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
