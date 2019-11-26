using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private Transform place;
    private Vector2 initialPosition;

    private GameController gameController;
    private float deltaX, deltaY;

    public bool locked;

    void Start()
    {
        gameController = 
        initialPosition = transform.position;
    }


    void Update()
    {
        //if (Input.touchCount > 0 && !locked) //SEM SIMULADOR
        if (!locked)
        {
            if(transform.position.x != initialPosition.x && initialPosition.y != transform.position.y)
            {
                transform.localScale = new Vector3(1, 1, 1);
            } else
            {
                transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - place.position.x) <= 0.5f &&
                       Mathf.Abs(transform.position.y - place.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(place.position.x, place.position.y);
                        locked = true;
                        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                    else
                    {
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
