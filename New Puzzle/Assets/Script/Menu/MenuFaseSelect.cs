﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuFaseSelect : MonoBehaviour
{
    public Slider slider;
    private AudioController audioController;
    AsyncOperation async;

    public int maxFase;
    public int fase;

    //Fases
    public GameObject fase_1;
    public GameObject lock_1;
    public GameObject fase_2;
    public GameObject lock_2;
    public GameObject fase_3;
    public GameObject lock_3;
    public GameObject fase_4;
    public GameObject lock_4;
    public GameObject fase_5;
    public GameObject lock_5;
    public GameObject fase_6;
    public GameObject lock_6;
    public GameObject fase_7;
    public GameObject lock_7;
    public GameObject fase_8;
    public GameObject lock_8;
    public GameObject fase_9;
    public GameObject lock_9;
    public GameObject fase_10;
    public GameObject lock_10;

    private List<String> fases = new List<string>();

    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        
    }
    public void GoToScene(string Scena)
    {
        Debug.Log("GGGGGGGGGGGGGGGGGG");
        //if (fases.Contains(Scena))
        //{
        Debug.Log(Scena);
            audioController.changeMusic(audioController.musicFase1, Scena, true, slider);
            //StartCoroutine(LoadScreen(Scena));
        //}
    }
    private void OpenLevel(string level)
    {
        Debug.Log(level);
        fases.Add(level);
        switch (level)
        {
            case "Fase_1":
                fase_1.SetActive(true);
                lock_1.SetActive(false);
                break;
           
            case "Fase_2":
                fase_2.SetActive(true);
                lock_2.SetActive(false);
                break;
            case "Fase_3":
                fase_3.SetActive(true);
                lock_3.SetActive(false);
                break;
            case "Fase_4":
                fase_4.SetActive(true);
                lock_4.SetActive(false);
                break;
            case "Fase_5":
                fase_5.SetActive(true);
                lock_5.SetActive(false);
                break;
            case "Fase_6":
                fase_6.SetActive(true);
                lock_6.SetActive(false);
                break;
            case "Fase_7":
                fase_7.SetActive(true);
                lock_7.SetActive(false);
                break;
            case "Fase_8":
                fase_8.SetActive(true);
                lock_8.SetActive(false);
                break;
            case "Fase_9":
                fase_9.SetActive(true);
                lock_9.SetActive(false);
                break;
            case "Fase_10":
                Debug.Log(fase_10.transform.position.x);
                Debug.Log(fase_10.transform.position.y);
                //fase_10.transform.position.x;
                fase_10.SetActive(true);
                lock_10.SetActive(false);
                break;
            case "Fase_11":
                fase_4.SetActive(true);
                lock_4.SetActive(false);
                break;
        }
    }

    IEnumerator LoadScreen(string scena)
    {
        
        if (async == null )
        {
            slider.gameObject.SetActive(true);
            async = SceneManager.LoadSceneAsync(scena);
            async.allowSceneActivation = false;
            while (async.isDone == false) {
                slider.value = async.progress;
                if (async.progress == 0.9f)
                {
                    slider.value = 1f;
                    async.allowSceneActivation = true;
                }
                yield return null;          
            }

        }
    }

    public void selectScene()
    {
        audioController.changeMusic(audioController.musicFase2, this.gameObject.name, true, slider);
    }
    public void selectMenu()
    {
        audioController.changeMusic(audioController.musicFase2, "Menu", true, slider);
    }
    public void clickSom()
    {
        audioController.playFx(audioController.fxClick, 1);
    }
    public void Reentry()
    {

        audioController.changeMusic(audioController.musicFase1, "Menu2", true, slider);
        SceneManager.LoadScene("Menu2");
    }

}
