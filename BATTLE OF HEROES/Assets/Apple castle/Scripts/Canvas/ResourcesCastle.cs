using UnityEngine;
using UnityEngine.UI;

public class ResourcesCastle : MonoBehaviour {

    public int Coins;
    public int Experience;
    public int LevelCastle = 1;
    public int Wave = 1;

    public float Timers = 120f;

    public GameObject Cl1;
    public GameObject Cl2;
    public GameObject Cl3;

    public Text CoinsText;
    public Text ExperienceText;
    public Text LevelCastleText;
    public Text WaveText;

    private float times;

    private bool Wave2 = false;
    private bool Wave3 = false;
    private bool Wave4 = false;
    private bool Wave5 = false;

    void Start()
    {
        times = Timers;
    }

    void Update()
    {
        WaveUp();
        Texts();
        Waves();
        LvlCastle();

    }

    void WaveUp()
    {
        
        if(Wave5 == true)
        {
            Wave = 5;
        }

        if(Wave == 2 && Wave2 == false)
        {
            gameObject.GetComponent<EnemySpawn>().TimerMax -= 2;
            Wave2 = true;
        }

        if(Wave == 3 && Wave3 == false)
        {
            gameObject.GetComponent<EnemySpawn>().TimerMax -= 3;
            Wave3 = true;
        }
        if(Wave == 4 && Wave4 == false)
        {
            gameObject.GetComponent<EnemySpawn>().TimerMin -= 1;
            gameObject.GetComponent<EnemySpawn>().TimerMax -= 4;
            Wave4 = true;
        }
        if (Wave == 5 && Wave5 == false)
        {
            gameObject.GetComponent<EnemySpawn>().TimerMin -= 2;
            gameObject.GetComponent<EnemySpawn>().TimerMax -= 4;
            Wave5 = true;
        }
    }

    void Texts()
    {
        CoinsText.text = Coins.ToString();
        ExperienceText.text = Experience.ToString();
        LevelCastleText.text = LevelCastle.ToString();
        WaveText.text = "Wave:" + Wave.ToString();
    }

    void Waves()
    {
        times -= Time.deltaTime;
        if(times <= 0)
        {
            Wave += 1;
            times = Timers;
        }
    }

    void LvlCastle()
    {
        if (Cl1.activeInHierarchy == true)
        {
            LevelCastle = 1;
        }
        if (Cl2.activeInHierarchy == true)
        {
            LevelCastle = 2;
        }
        if (Cl3.activeInHierarchy == true)
        {
            LevelCastle = 3;
        }
    }
}
