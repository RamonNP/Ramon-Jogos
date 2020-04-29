using UnityEngine;

public class AI : MonoBehaviour {

    public float Speed;
    private Vector2 Point;
    public GameObject ObjPoint;
    private Rigidbody2D rb;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Point = ObjPoint.transform.position;
	}
	

	void FixedUpdate () {   
        Motion();
	}

    void Motion()
    {
        rb.velocity = Vector3.down;
        rb.MovePosition(rb.position + Point * Time.fixedDeltaTime * Speed);
    }
    void OnCollisionStay2D(Collision2D colls)
    {
        if (colls.gameObject.tag == "Enemy")
        {
           Physics2D.IgnoreCollision(gameObject.transform.GetComponent<Collider2D>(), colls.transform.GetComponent<Collider2D>());
        }
    }
}
