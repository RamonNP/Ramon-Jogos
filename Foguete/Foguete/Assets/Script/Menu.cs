using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private AudioController audioController;
    public Slider slider;

    private void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }
    public void selectScene()
    {
        //Debug.Log(slider);
        audioController.changeMusic(audioController.musicFase2, this.gameObject.name, true, slider);
    }
    public void selectMenu()
    {
        Debug.Log("QUITTTTTT");
        audioController.changeMusic(audioController.musicFase2, "Menu", true, slider);
    }
    public void clickSom()
    {
        audioController.playFx(audioController.fxClick, 1);
    }
}
