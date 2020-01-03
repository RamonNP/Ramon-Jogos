using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public AudioClip fxLetra;
    [SerializeField]
    private Transform place;
    private Vector2 initialPosition;

    private GameController gameController;
    private float deltaX, deltaY;

    public bool locked;
    public bool move;


    //efeito quando arrasta pega aumenta.
    float x;
    float y;
    float z;
    float xN;
    float yN;


    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        initialPosition = transform.position;
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        xN = x * 1.3f;
        yN = y * 1.3f;


    }


    void Update()
    {
        //if (Input.touchCount > 0 && !locked) //SEM SIMULADOR
        if (!locked)
        {
            
            if (transform.position.x != initialPosition.x && initialPosition.y != transform.position.y)
            {
                transform.localScale = new Vector3(xN, yN, z);
            } else
            {
                transform.localScale = new Vector3(x, y, z);
            }
            Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        Debug.Log("BeganBeganBeganBegan");
                        gameController.playFx(fxLetra);
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        move = true;
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    } 
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - place.position.x) <= 1.0f &&
                       Mathf.Abs(transform.position.y - place.position.y) <= 1.0f)
                    {
                        transform.position = new Vector2(place.position.x, place.position.y);
                        locked = true;
                        transform.localScale = new Vector3(x, y, z);
                        gameController.addRight();
                        gameController.playFx(fxLetra);
                    }
                    else
                    {
                        if(initialPosition.x != transform.position.x)
                        {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                            
                            gameController.addError();
                            move = false;
                        }
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
