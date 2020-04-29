using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleLvlUp : MonoBehaviour {

    public GameObject CastleUp;
    public int Price = 2000;

    public void LevelUp()
    {
        GameObject res = GameObject.Find("Main Camera");
        //if(res.GetComponent<ResourcesCastle>().Coins >= Price)
        {
            res.GetComponent<ResourcesCastle>().Coins -= Price;
            CastleUp.SetActive(true);
            Destroy(gameObject);
        }

    }
}
