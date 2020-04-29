using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float DammageCastle = 200f;
    public float TimeLeft = 2f;
    private float NewTimeLeft;

    void Start()
    {
        NewTimeLeft = TimeLeft;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Castle")
        {
            TimeLeft -= Time.deltaTime;
            if(TimeLeft <= 0)
            {
                other.GetComponent<CastleHealth>().HealthCastle -= DammageCastle;
                gameObject.GetComponent<AI>().Speed = 0f;
                TimeLeft = NewTimeLeft;
            }
        }
    }
}
