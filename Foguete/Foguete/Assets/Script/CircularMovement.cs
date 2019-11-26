using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour {

	[SerializeField]
	Transform rotationCenter;

	[SerializeField]
	float rotationRadius = 2f, angularSpeed = 2f;

    private Animator playeAnimator;
    public int idAnimation; //INDICA ID DA ANIMAÇÂO 

    public float angle = 0;

    float posX, posY;
    public bool rocket;
    private void Start()
    {
        //this.tag = "Fuel";
        playeAnimator = GetComponent<Animator>();
        idAnimation = Random.Range(1, 5);
        //Debug.Log();
        if(idAnimation == 4)
        {
            this.tag = "Box";
        }
        if(!rocket)
        {
            playeAnimator.SetInteger("animation", idAnimation);
        }
    }

    // Update is called once per frame
    void Update () {
		posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
		transform.position = new Vector2 (posX, posY);
		angle = angle + Time.deltaTime * angularSpeed;

		if (angle >= 360f)
			angle = 0f;
    }
}
