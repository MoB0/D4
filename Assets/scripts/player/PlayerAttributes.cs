using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public char PlayerClass;

    public int WalkSpeed;
    public int Str;
    public int Dex;
    public int Intelligence;
    public int AttackRate;
    public int Stamina;

    public float MeleeRange;
    public float RangedRange;

    GameObject classManager;

    private void Awake()
    {
        classManager = GameObject.Find("classManager");

        
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerClass == 'K')
        {
            WalkSpeed = classManager.GetComponent<Knight>().WalkSpeed;
            Str = classManager.GetComponent<Knight>().Str;
            Dex = classManager.GetComponent<Knight>().Dex;
            Intelligence = classManager.GetComponent<Knight>().Intelligence;
            AttackRate = classManager.GetComponent<Knight>().AttackSpeed;
            Stamina = classManager.GetComponent<Knight>().Stamina;
            MeleeRange = classManager.GetComponent<Knight>().MeleeRange;
            RangedRange = classManager.GetComponent<Knight>().RangedRange;
        }
        if (PlayerClass == 'M')
        {
            WalkSpeed = classManager.GetComponent<Mage>().WalkSpeed;
            Str = classManager.GetComponent<Mage>().Str;
            Dex = classManager.GetComponent<Mage>().Dex;
            Intelligence = classManager.GetComponent<Mage>().Intelligence;
            AttackRate = classManager.GetComponent<Mage>().AttackSpeed;
            Stamina = classManager.GetComponent<Mage>().Stamina;
            MeleeRange = classManager.GetComponent<Mage>().MeleeRange;
            RangedRange = classManager.GetComponent<Mage>().RangedRange;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
