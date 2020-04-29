using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LookAtAI : MonoBehaviour {

    public Transform Target;
    private GameObject MyOneTarget;
    private GameObject[] MyTargets;



    enum FacingDirection
    {
        UP = 270,
        DOWN = 90,
        LEFT = 180,
        RIGHT = 0
    }

    void Update()
    {
        DistanceObjects();
    }

    void DistanceObjects()
    {
        MyTargets = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < MyTargets.Length; i += 1)
        {
            MyOneTarget = MyTargets[0];
            Target = MyOneTarget.transform;        
        }
        if(Target != null)
        {
            LookAt2D(Target, 17f, FacingDirection.RIGHT);
        }
    }

    void LookAt2D(Transform theTarget, float theSpeed, FacingDirection facing)
    {
        Vector3 vectorToTarget = theTarget.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y + 30, vectorToTarget.x) * Mathf.Rad2Deg;
        angle -= (float)facing;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * theSpeed);
    }
}
