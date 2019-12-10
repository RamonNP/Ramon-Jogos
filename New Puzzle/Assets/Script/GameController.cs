using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider slider;
    public GameObject hudGameOver;
    private AudioController audioController;
    public int right;
    public int error;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        right = 0;
        error = 0;
        hudGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addRight()
    {
        right++;
        if (right >= 3)
        {
            victory();
            audioController.playFx(audioController.fxVictory, 1);
        } else
        {
            audioController.playFx(audioController.fxSuccess, 1);
        }
        Debug.Log(" right" + right);
    }
    public void addError()
    {
        error++;
        audioController.playFx(audioController.fxError, 1);
    }

    public void victory()
    {
        hudGameOver.SetActive(true);
        Debug.Log(" victory ");
        audioController.pauseMusic();
    }
    public void Reentry()
    {
        this.
        hudGameOver.SetActive(false);
        Debug.Log(" Reentry "+ audioController.newScene);

        audioController.changeMusic(audioController.musicFase1, audioController.newScene, true, slider);
        SceneManager.LoadScene(audioController.newScene);
    }
    public void Menu()
    {
        audioController.changeMusic(audioController.musicTitle, "Menu2", true, slider);
    }
    public void Next()
    {

    }
}
