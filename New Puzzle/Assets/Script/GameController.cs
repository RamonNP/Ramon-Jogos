using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum CATEGORIA { ESCREVER = 0, LER = 1000, ENCAIXE = 20, OUTROS = 8 };
    public enum TIPO { ANIMAIS = 0, OBJETOS = 100, FRUTAS = 200, OUTROS = 8 };



    public CATEGORIA cat;
    public TIPO tipo;
    private int fases;
    public static Dictionary <int, float> itensPosition;
    public int lockKK;
    public int pontos;
    public Slider slider;
    public GameObject hudGameOver;
    private AudioController audioController;
    public int right;
    public int error;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        right = 0;
        error = 0;
        hudGameOver.SetActive(false);
        fases = 4;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void playFx(AudioClip fxAudio)
    {
        audioController.playFx(fxAudio, 1);
    }

    public void addRight()
    {
        right++;
        if (right >= pontos)
        {
            victory();

            coroutine = playVictoryEnum();
            StartCoroutine("playVictoryEnum");
        } else
        {
           // audioController.playFx(audioController.fx, 1);
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

        //audioController.changeMusic(audioController.musicFase1, "Fase_" + audioController.faseAtual, true, slider);
        SceneManager.LoadScene("Fase_"+ (cat + (int) tipo + audioController.faseAtual));
    }
    public void Menu()
    {
        
        audioController.changeMusic(audioController.musicTitle, "Menu2", true, slider);
        SceneManager.LoadScene("Menu2");
    }
    public void Next()
    {
        int proximaFase = ((audioController.faseAtual % fases)+1)+ (int) cat + (int )tipo;
        Debug.Log(proximaFase);
        audioController.changeMusic(audioController.musicFase1, "Fase_" + proximaFase, true, slider);
        SceneManager.LoadScene("Fase_"+ proximaFase);
    }

    public void resizeColiderMax(BoxCollider2D bc2d, SpriteRenderer spriteRenderer)
    {
        bc2d.size = new Vector2(2f, 3f);
        spriteRenderer.sortingOrder = 5;
    }
    public void resizeColiderMaxPalavra(BoxCollider2D bc2d, SpriteRenderer spriteRenderer, float x, float y)
    {
        bc2d.size = new Vector2(x, y);
        spriteRenderer.sortingOrder = 5;
    }
    public void resizeColiderMin(BoxCollider2D bc2d)
    {
        bc2d.size = new Vector2(0.00001f, 0.00001f);
    }

    /*
    public void initList()
    {
        itensPosition = new Dictionary<int, float>();
        float position = 0f;
        int i = 0;
        //while (itensPosition.Count < 5 || i >100) retorna 

        retornar lista de posiçoes
        {
            i++;
            int number = Random.Range(0, 5);
            if(!itensPosition.ContainsKey(number))
            {
                Debug.Log(number +" Poition "+ position);
                position = position + 3.2f;
                itensPosition[1] = position;
            }
        }
    }*/
    IEnumerator playVictoryEnum()
    {
        yield return new WaitForSecondsRealtime(1f);
        audioController.playFx(audioController.fxPalavra, 1);
        yield return new WaitForSecondsRealtime(0.5f);
        audioController.playFx(audioController.fxVictory, 1);

    }
}
