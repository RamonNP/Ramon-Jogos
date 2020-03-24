﻿using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    public AudioController instance;
    public float tempoInciarPalavra;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }
    public Slider slider;
    private IEnumerator coroutine;
    public AudioSource sMusic;
    public AudioSource sFX;

    //public Slider slider;

    AsyncOperation async;

    [Header("Music")]
    public AudioClip musicTitle;
    public AudioClip musicFase1;
    public AudioClip musicFase2;

    [Header("Sound")]

    public AudioClip fxFrase;
    public AudioClip fxClick;
    public AudioClip fxPalavra;
    public AudioClip fxError;
    public AudioClip fxVictory;


    public float maxVol;
    public float minVol;

    private AudioClip newMusic;
    public int faseAtual;
    private string tradeScene;
    private bool changeScene;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        maxVol = 1;
        minVol = 1;
        

        changeMusic(musicTitle, "Menu2", false, null);
        coroutine = playAudioEnum();
        StartCoroutine("playAudioEnum");
    }

    public void changeMusic(AudioClip clip, string newScene, bool changeScene, Slider slider2)
    {

        if (slider2 != null)
        {
            slider = slider2;
        } else
        {
            slider = (Slider) FindObjectOfType<Slider>();
        }
        this.tradeScene = newScene;
        this.newMusic = clip;
        this.changeScene = changeScene;
        coroutine = changeMusicEnum();
        StartCoroutine("changeMusicEnum");
    }
    /*
    private IEnumerator changeMusicEnum()
    {
        for (float volume = maxVol; volume >= 0; volume -= 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            sMusic.volume = volume;
        }
        sMusic.volume = 0;
        sMusic.clip = newMusic;
        sMusic.Play();

        for (float volume = 0; volume < maxVol; volume += 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            sMusic.volume = volume;
        }
        sMusic.volume = maxVol;
        if (changeScene)
        {
            SceneManager.LoadScene(newScene);
        }
    }*/


    IEnumerator changeMusicEnum()
    {
        if (changeScene)
        {

            //Debug.Log(async == null);
            if (async == null && slider != null)
            {
                slider.gameObject.SetActive(true);
                async = SceneManager.LoadSceneAsync(tradeScene);
                async.allowSceneActivation = false;
                while (async.isDone == false)
                {
                    //Debug.Log(newScene);
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
        for (float volume = maxVol; volume >= 0; volume -= 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            sMusic.volume = volume;
        }
        sMusic.volume = 0;
        sMusic.clip = newMusic;
        sMusic.Play();

        for (float volume = 0; volume < maxVol; volume += 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            sMusic.volume = volume;
        }
        sMusic.volume = maxVol;
        async = null;
    }
    public void playPalavra()
    {
        sFX.Stop();
        coroutine = playAudioEnum();
        StartCoroutine("playAudioEnum");
    }

    public void playFx(AudioClip fx, float volume)
    {
        float tempVolume = volume;
        if (volume > maxVol)
        {
            tempVolume = maxVol;
        }
        sFX.volume = tempVolume;
        if(fx != null)
        {
            sFX.PlayOneShot(fx);
        }
    }
    public void pauseMusic()
    {
        sMusic.Pause();
    }
    public IEnumerator playAudioEnum()
    {
        yield return new WaitForSecondsRealtime(tempoInciarPalavra);
        playFx(fxFrase, 1);
    }


    
}
