using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyArmy : MonoBehaviour
{
    public GameObject ApplePrefab;
    public int Price = 500;

    public void BuyMyArmy()
    {
        GameObject Res = GameObject.Find("Main Camera");
        //if (Res.GetComponent<ResourcesCastle>().Coins >= Price)
        {
            Res.GetComponent<ResourcesCastle>().Coins -= Price;
            Instantiate(ApplePrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
