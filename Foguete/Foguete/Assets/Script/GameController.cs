using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    PAUSE, GAMEPLAY, GAMEOVER
}
 
public class GameController : MonoBehaviour
{
    public GameState currenteState;
    [Header("ScoreTxt")]
    public TextMeshProUGUI scoreUpTxt;
    public TextMeshProUGUI scoreGameOver;
    [Header("Panel")]
    public GameObject painelPause;
    [Header("GameOver")]
    public GameObject painelGameOver;

    private AudioController audioController;
    public List<GameObject> preFabs;
    public GameObject fuel;
    public Transform cam;

    public float intervalObstacle;
    public float nexObstacle = 0f;

    private int tipelObstacle;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        currenteState = GameState.GAMEPLAY;
        painelPause.SetActive(false);
        painelGameOver.SetActive(false);
        cam = Camera.main.transform;
        nexObstacle += intervalObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currenteState == GameState.GAMEPLAY)
        {
            createObstacle();
        }
    }

    public void createObstacle()
    {
       // Debug.Log(cam.position.y);
        //Debug.Log(nexObstacle);
        if (cam.position.y > nexObstacle)
        {
            nexObstacle += intervalObstacle;
            tipelObstacle = Random.Range(0, preFabs.Count);
            
            transform.position = new Vector3(0f, cam.position.y+ intervalObstacle, 0);
            Instantiate(preFabs[tipelObstacle], transform.position, Quaternion.identity);
            tipelObstacle = Random.Range(0, 10);
            if(tipelObstacle > 7)
            {
                Instantiate(fuel, transform.position, Quaternion.identity);
            }
        }
    }

    public void pauseGame()
    {
        painelPause.SetActive(!painelPause.activeSelf);
        Debug.Log(painelPause.activeSelf);
        if(painelPause.activeSelf)
        {
            audioController.pauseFxEngine();
            Time.timeScale = 0;
            changeState(GameState.PAUSE);
        } else
        {
            Time.timeScale = 1;
            changeState(GameState.GAMEPLAY);
        }
    }
    public void gameOver()
    {
        
        painelGameOver.SetActive(true);
        //changeState(GameState.GAMEOVER);
    }
    public void changeState(GameState gameState)
    {
        currenteState = gameState;
    }
    public void updateTxt(TextMeshProUGUI scoreUpTxt, int value, int mask)
    {
        scoreUpTxt.text = value.ToString().PadLeft(mask, '0');
    }
}
