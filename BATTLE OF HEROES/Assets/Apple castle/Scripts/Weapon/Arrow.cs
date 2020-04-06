using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool Fly = true;
    public float Damage = 20f;

    void FixedUpdate()
    {
        ArrowEnd();
        ArrowRot();
        Destroy(gameObject, 4);
    }

    void ArrowRot()
    {
        if(GetComponent<Rigidbody2D>() != null)
        {
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void ArrowEnd()
    {
        if(Fly== false)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
/*
       void OnCollisionEnter2D(Collision2D other)
       {
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "Player" || other.gameObject.tag == "Friend" || other.gameObject.tag == "Castle")
        {
            var d = gameObject.transform;
            Physics2D.IgnoreCollision(d.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "Player" || other.gameObject.tag == "Friend" || other.gameObject.tag == "Castle")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        }
        else
        {
            Fly = false;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<HealthEnemy>().HealthE -= Damage / 3.01f;
        }
    }
}
