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
    private int MASK = 4;
    public GameState currenteState;
    [Header("ScoreTxt")]
    public TextMeshProUGUI scoreUpTxt;
    public TextMeshProUGUI coinTxt;
    public TextMeshProUGUI scoreGameOver;
    public TextMeshProUGUI maxScoreGameOver;
    [Header("Panel")]
    public GameObject painelPause;
    [Header("GameOver")]
    public GameObject painelGameOver;

    private AudioController audioController;
    public List<GameObject> preFabsObstacle;
    public List<GameObject> preFabsBonus;

    public Transform cam;

    public float intervalObstacle;
    public float nexObstacle = 0f;
    private int scoreMaxSave;
    private int currentScore;
    private int coinSave;
    private int tipelObstacle;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        currenteState = GameState.GAMEPLAY;
        retrieveCoin();
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
        //Debug.Log(nexObstacle);
        if (cam.position.y > nexObstacle)
        {
        Debug.Log("SAVEEEEEEEEEEEE" + currentScore);
            nexObstacle += intervalObstacle;
            if(currentScore < 40)
            {
                tipelObstacle = Random.Range(0, 1);
            } else if (currentScore < 80)
            {
                tipelObstacle = Random.Range(0, 2);
            } else if (currentScore < 200)
            {
                tipelObstacle = Random.Range(0, 3);
            } else
            {
                tipelObstacle = Random.Range(0, preFabsObstacle.Count);
            }

            //tipelObstacle = Random.Range(0, preFabsObstacle.Count);
            
            transform.position = new Vector3(0f, cam.position.y+ intervalObstacle, 0);
            Instantiate(preFabsObstacle[tipelObstacle], transform.position, Quaternion.identity);
            tipelObstacle = Random.Range(0, 10);
           /* if(tipelObstacle > 7)
            {
                Instantiate(fuel, transform.position, Quaternion.identity);
            } */
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
    public void gameOver(int score)
    {
        saveCoin(coinSave);
        painelGameOver.SetActive(true);
        /*if(score > PlayServiceRamon.GetPlayerScore(GPGSIds.leaderboard_flying_rocket_ranking))
        {
            PlayServiceRamon.PostScore((long)score, GPGSIds.leaderboard_flying_rocket_ranking);
        } */
        //changeState(GameState.GAMEOVER);
    }
    public void changeState(GameState gameState)
    {
        currenteState = gameState;
    }
    public void updateTxt(TextMeshProUGUI scoreUpTxt, int value, int mask)
    {
        scoreUpTxt.text = value.ToString().PadLeft(mask, '0');
        currentScore = value;
    }

    public void saveNewScore(int value)
    {
        if(scoreMaxSave < value)
        {
            scoreMaxSave = PlayerPrefs.GetInt("scoreMaxSave");
            if (scoreMaxSave < value)
            {
                PlayerPrefs.SetInt("scoreMaxSave", value);
                scoreMaxSave = value;
            }
        }
        maxScoreGameOver.text = scoreMaxSave.ToString().PadLeft(8, '0');
    }
    public void saveCoin(int value)
    {
        Debug.Log("save - "+ value);
        PlayerPrefs.SetInt("CoinSave", value);
    }
    public void addCoin()
    {
        coinSave++;
        coinTxt.text = coinSave.ToString().PadLeft(MASK, '0');
        Debug.Log("add - "+ coinSave);
    }

    public void retrieveCoin()
    {
        coinSave = PlayerPrefs.GetInt("CoinSave");
        Debug.Log("RETRIEVE - " + coinSave);
        coinTxt.text = coinSave.ToString().PadLeft(MASK, '0');
    }
    public void CreateBonus(float corY)
    {

        tipelObstacle = Random.Range(0, 100);
        // create fuel
        if (tipelObstacle < 60)
        {
            tipelObstacle = Random.Range(0, preFabsBonus.Count);
        }
        //create coins
        else
        {
            tipelObstacle = 0;
        }

        transform.position = new Vector3(0f, corY, 0);
        Instantiate(preFabsBonus[tipelObstacle], transform.position, Quaternion.identity);
        
    }
}
