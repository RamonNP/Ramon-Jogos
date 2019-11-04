using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInfinitBackGround : MonoBehaviour
{
    private Transform TargetToFollow;

    public GameObject backGround1;
    public GameObject backGround2;

    void Start()
    {
        TargetToFollow = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.transform.position.y > backGround1.transform.position.y + 15)
        {
            backGround1.transform.position = new Vector3(backGround1.transform.position.x, backGround1.transform.position.y + 35.28f);

        }
        if (transform.transform.position.y > backGround2.transform.position.y + 15)
        {
            backGround2.transform.position = new Vector3(backGround2.transform.position.x, backGround2.transform.position.y + 35.28f);

        }
    }
}
