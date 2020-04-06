using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour {

    public Slider Slider;
    public float HealthE = 100f;

    public int ExpMin = 1;
    public int ExpMax = 5;

    public int CoinMin = 10;
    public int CoinMax = 20;

    private int Exp;
    private int Coin;

    private GameObject Res;

    void Start()
    {
        Exp = Random.Range(ExpMin, ExpMax);
        Coin = Random.Range(CoinMin, CoinMax);
        Slider.maxValue = HealthE;
        Res = GameObject.Find("Main Camera");
    }

	void Update () {

        Main();
	}
    
    void Main()
    {
        Slider.value = HealthE;

        if(HealthE <= 0)
        {
            if(Res.GetComponent<ResourcesCastle>() != null)
            {
                Res.GetComponent<ResourcesCastle>().Experience += Exp;
                Res.GetComponent<ResourcesCastle>().Coins += Coin;
            }
            Destroy(gameObject);
        }
    }
}
