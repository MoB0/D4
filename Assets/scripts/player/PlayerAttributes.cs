using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
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
        if (GetComponent<PlayerClass>().Class == 'K')
        {
            //WalkSpeed = GetComponent<Knight>().WalkSpeed;
            WalkSpeed = 7;
            Str = GetComponent<Knight>().Str;
            Dex = GetComponent<Knight>().Dex;
            Intelligence = GetComponent<Knight>().Intelligence;
            AttackSpeed = GetComponent<Knight>().AttackSpeed;
            Stamina = GetComponent<Knight>().Stamina;
        }
        if (GetComponent<PlayerClass>().Class == 'M')
        {
            WalkSpeed = GetComponent<Mage>().WalkSpeed;
            Str = GetComponent<Mage>().Str;
            Dex = GetComponent<Mage>().Dex;
            Intelligence = GetComponent<Mage>().Intelligence;
            AttackSpeed = GetComponent<Mage>().AttackSpeed;
            Stamina = GetComponent<Mage>().Stamina;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
