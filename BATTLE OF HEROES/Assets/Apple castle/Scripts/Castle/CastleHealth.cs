using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CastleHealth : MonoBehaviour {

    public Slider Sliders;
    public float HealthCastle = 1000f;
    public GameObject YouLose;
	
    void Start()
    {
        Sliders.maxValue = HealthCastle;
    }

	void Update () {

        Sliders.value = HealthCastle;

        StartCoroutine(HealthNull());

	}
    IEnumerator HealthNull()
    {
        if (HealthCastle <= 0)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Time.timeScale = 1;
            }

            YouLose.SetActive(true);           
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(0);
        }
    }
}
