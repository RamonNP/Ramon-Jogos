using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class JetPack : MonoBehaviour
{

    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    private bool teste = true;
    public GameController gameController;
    private bool dead;
    private Animator naveAnimator;
    public GameObject nave;
    public GameObject shield;
    public TextMeshProUGUI fuelTxt;
    private Rigidbody2D rb;
    private float jumpForce = 3f;
    public static bool engineIsOn;
    Touch touch = new Touch();
    public float fuelLoss;
    public float fuelPlus;
    private float fuel;
    [SerializeField]
    private GameObject fire;
    [SerializeField]    
    public GameObject coinParticle;
    public GameObject FuelParticle;
    public GameObject ShieldParticle;
    private int upMax;
    private IEnumerator coroutine;

    private AudioController audioController;


        // Start is called before the first frame update
    void Start()
    {

        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        audioController.playFxEngine(audioController.fxRocket, 1);
        audioController.pauseFxEngine();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        naveAnimator = GetComponent<Animator>();
        fuel = 100f;
        if (teste)
        {
            //SIMULATE TOUCH
            touch = new Touch();
            touch.phase = TouchPhase.Moved;
            touch.position = Input.mousePosition;
            //SIMULATE TOUCH  */  
        }

        Time.timeScale = 1f;
        engineIsOn = false;
        fire.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.currenteState == GameState.GAMEPLAY && !dead)
        {
            changeUpMax();
            int f = (int)fuel;
            fuelTxt.text = f.ToString() + "%";
            if (teste)
            {
                simulateMovimente();
            } else
            {
                movimente();
            }
        }
        

    }
    private void changeUpMax()
    {
        //Debug.Log(transform.position.y + "- "+upMax);
        //Debug.Log(upMax);
        if (transform.position.y > upMax)
        {
            upMax = (int) transform.position.y;
            gameController.updateTxt(gameController.scoreUpTxt, upMax, 5);
        }
    }
    private void movimente()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            engineIsOn = false;
            audioController.pauseFxEngine();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            engineIsOn = true;
            if (gameController.currenteState.Equals(GameState.GAMEPLAY))
            {
                audioController.playFxEngine();
            }
        }
    }

    private void simulateMovimente()
    {
        Touch touch = simulatess();
        if (touch.phase == TouchPhase.Ended)
        {
            engineIsOn = false;
            audioController.pauseFxEngine();
        }
        if (touch.phase == TouchPhase.Began)
        {
            engineIsOn = true;
            if (gameController.currenteState.Equals(GameState.GAMEPLAY))
            {
                audioController.playFxEngine();
            }

        }
    }

    private void FixedUpdate()
    {
        if (gameController.currenteState == GameState.GAMEPLAY && !dead)
        {
            if (fuel <=  0f)
            {
                engineIsOn = false;
            }
            switch (engineIsOn)
            {
                case true:
                    if (fuel > 0f)
                    {
                        fire.SetActive(true);
                        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                        fuel -= fuelLoss;
                        
                    }
                    break;
               case false:
                    
                    rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                    if(fuel < 100f)
                    {
                        fuel += fuelPlus;
                    }
                    fire.SetActive(false);
                    break;

            }
        }
    }

    public void gameOver()
    {
        //salvar Atual maior que maximo 
        gameController.saveNewScore(upMax);
        //FIM
        gameController.updateTxt(gameController.scoreGameOver, upMax, 8);
        gameController.changeState(GameState.GAMEOVER);
        audioController.pauseFxEngine();
        audioController.playFx(audioController.fxExplosion, 1);
        //StartCoroutine("ReloadScene");
        //Time.timeScale = 0f;
        naveAnimator.SetBool("Explosion", true);
        fire.SetActive(false);
        dead = true;

        rb.gravityScale = 0.02f;
        //SceneManager.LoadScene("Fase1");
        coroutine = WaitAndPrint(1.3f);
        StartCoroutine(coroutine);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
        {
            //Debug.Log(collision.tag);
            if (collision.CompareTag("Meteor")) //(collision.name.Equals("asteroid"))
            {
                if (shield.activeSelf)
                {
                    Instantiate(ShieldParticle, transform.position, Quaternion.identity);
                    audioController.pauseFxEngine();
                    audioController.playFx(audioController.fxExplosion, 1);
                    shield.SetActive(false);
                } else
                {
                    gameOver();
                }
            }
            else if (collision.CompareTag("Fuel"))
            {
                audioController.playFx(audioController.fxGetFuel, 1);
                fuel += 30f;
                Instantiate(FuelParticle, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Shield"))
            {
                audioController.playFx(audioController.fxGetFuel, 1);
                Instantiate(ShieldParticle, collision.transform.position, Quaternion.identity);
                shield.SetActive(true);
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Box"))
            {
              
                audioController.playFx(audioController.fxGetFuel, 1);
                gameController.CreateBonus(collision.transform.position.y+1);
                Instantiate(ShieldParticle, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Coin"))
            {
                //createBomb();
                audioController.playFx(audioController.fxGetFuel, 1);
                Instantiate(coinParticle, collision.transform.position, Quaternion.identity);
                gameController.addCoin();
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Bomb"))
            {
                createBomb();
                audioController.playFx(audioController.fxGetFuel, 1);
                //Instantiate(coinParticle, collision.transform.position, Quaternion.identity);
                //gameController.addCoin();
                Destroy(collision.gameObject);
            }
        }
       
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            gameController.gameOver(upMax);
        }
    }

    private void Destroy()
    {
        SceneManager.LoadScene("Fase1");
    }

    private Touch simulatess()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Began;
            touch.position = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Began;
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
    private void createBomb()
    {

        Debug.Log("createBomb");
        bomb1.SetActive(true); ;
        bomb2.SetActive(true); ;
        bomb3.SetActive(true); ;
        bomb1.GetComponent<BombScript>().finishBum();
        bomb2.GetComponent<BombScript>().finishBum();
        bomb3.GetComponent<BombScript>().finishBum();
    }
    
}
