using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    [SerializeField]
    private Transform bearPlace;
    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public bool locked;

    void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
        //if (Input.touchCount > 0 && !locked) //SEM SIMULADOR
        if(!locked)
        {
            Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;

                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - bearPlace.position.x) <= 0.5f &&
                       Mathf.Abs(transform.position.y - bearPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
                        locked = true;
                    } else {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                break;

            }
        }
    }
    private Touch simulatess()
    {
        Touch touch = new Touch();
        if (Input.GetMouseButtonDown(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Began;
            touch.position = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Moved;
            touch.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Ended;
            touch.position = Input.mousePosition;
        }
        return touch;
    }
}
