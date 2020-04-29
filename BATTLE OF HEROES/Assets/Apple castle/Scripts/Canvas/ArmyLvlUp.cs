using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyLvlUp : MonoBehaviour {

    public int PriceSkill = 200;
    public float rate = 1;
    public float rateAi = 2;
    public GameObject Bow;
    public GameObject BowAI;

    public void RateOfFire()
    {
        GameObject Res = GameObject.Find("Main Camera");
        //if(Res.GetComponent<ResourcesCastle>().Experience >= PriceSkill && Res.GetComponent<ResourcesCastle>().Coins >= PriceSkill * 3)
        {
            Res.GetComponent<ResourcesCastle>().Experience -= PriceSkill;
            Res.GetComponent<ResourcesCastle>().Coins -= PriceSkill;
            if(Bow != null)
            {
                Bow.GetComponent<Bow>().RateOfFire -= rate;
            }
            if(BowAI != null)
            {
                BowAI.GetComponent<BowAI>().RateOfFire -= rateAi;
            }
            Destroy(gameObject);
        }
    }
}
