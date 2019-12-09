using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
}
