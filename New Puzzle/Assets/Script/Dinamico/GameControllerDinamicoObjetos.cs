using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerDinamicoObjetos : MonoBehaviour
{
    public string[] palavras = new String[3];
    public AudioClip audioFase1;
    public AudioClip audioFase2;
    public AudioClip audioFase3;
    public AudioClip audioFase4;
    public AudioClip audioFase5;


    public AudioClip audioA;
    public AudioClip audioB;
    public AudioClip audioC;
    public AudioClip audioD;
    public AudioClip audioE;
    public AudioClip audioF;
    public AudioClip audioG;
    public AudioClip audioH;
    public AudioClip audioI;
    public AudioClip audioJ;
    public AudioClip audioK;
    public AudioClip audioL;
    public AudioClip audioM;
    public AudioClip audioN;
    public AudioClip audioO;
    public AudioClip audioP;
    public AudioClip audioQ;
    public AudioClip audioR;
    public AudioClip audioS;
    public AudioClip audioT;
    public AudioClip audioU;
    public AudioClip audioV;
    public AudioClip audioX;
    public AudioClip audioY;
    public AudioClip audioZ;
    public AudioClip audioW;
   
   

    public Sprite letraA;
    public Sprite letraB;
    public Sprite letraC;
    public Sprite letraD;
    public Sprite letraE;
    public Sprite letraF;
    public Sprite letraG;
    public Sprite letraH;
    public Sprite letraI;
    public Sprite letraJ;
    public Sprite letraK;
    public Sprite letraL;
    public Sprite letraM;
    public Sprite letraN;
    public Sprite letraO;
    public Sprite letraP;
    public Sprite letraQ;
    public Sprite letraR;
    public Sprite letraS;
    public Sprite letraT;
    public Sprite letraU;
    public Sprite letraV;
    public Sprite letraX;
    public Sprite letraW;
    public Sprite letraY;
    public Sprite letraZ;



    private string palavra;
    public GameObject ok1;
    public GameObject ok2;
    public GameObject ok3;
    public GameObject ok4;
    public GameObject ok5;
    public GameObject ok6;
    public GameObject fundo1;
    public GameObject fundo2;
    public GameObject fundo3;
    public GameObject fundo4;
    public GameObject fundo5;
    public GameObject fundo6;
    private int posicao = 1;
    private AudioController audioController;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    public static int faseAtual;
    public int right;
    public int error;
    public int pontos;
    public GameObject hudGameOver;
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        if(faseAtual == 0)
        {
            audioController.fxFrase = audioFase1;
            palavra = palavras[0];
        } else if (faseAtual == 1)
        {
            audioController.fxFrase = audioFase2;
            palavra = palavras[1];
        } else if (faseAtual == 2)
        {
            audioController.fxFrase = audioFase3;
            palavra = palavras[2];
        }
        tamanhoPalavra();
        montarPalavra();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playPalavra()
    {audioController.playPalavra();
}
    public void proximaFase()
    {

        posicao = 1;
        faseAtual++;
        faseAtual = faseAtual % 3;
        palavra = palavras[faseAtual];
        reiniciarParametros();
        escolherAudio(faseAtual);
        tamanhoPalavra();
        montarPalavra();
        playPalavra();
    }

    private void reiniciarParametros()
    {
        ok1.SetActive(true);
        fundo1.SetActive(true);
        ok2.SetActive(true);
        fundo2.SetActive(true);
        ok3.SetActive(true);
        fundo3.SetActive(true);
        ok4.SetActive(true);
        fundo4.SetActive(true);
        ok5.SetActive(true);
        fundo5.SetActive(true);
        ok6.SetActive(true);
        fundo6.SetActive(true);

    }
    public void playFx(AudioClip fxAudio)
    {
        audioController.playFx(fxAudio, 1);
    }
    private void escolherAudio(int faseAtual)
    {
        switch (faseAtual+1)
        {
            case 1:
                audioController.fxFrase = audioFase1;
                break;
            case 2:
                audioController.fxFrase = audioFase2;
                break;
            case 3:
                audioController.fxFrase = audioFase3;
                break;
            case 4:
                audioController.fxFrase = audioFase4;
                break;
            case 5:
                audioController.fxFrase = audioFase5;
                break;
            default:
                break;
        }
    }
    private void tamanhoPalavra()
    {
        int qtd = palavra.Length;

        switch (qtd)

        {
            case 4:
                posicao = 2;
                ok1.SetActive(false);
                fundo1.SetActive(false);
                ok6.SetActive(false);
                fundo6.SetActive(false);
                break;
            case 5:
                ok6.SetActive(false);
                fundo6.SetActive(false);
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    public GameObject getOk()
    {
        if(posicao == 1)
        {
            posicao++;
            return ok1;
        } else if(posicao == 2) {
            posicao++;
            return ok2;
        } else if(posicao == 3) {
            posicao++;
            return ok3;
        } else if(posicao == 4) {
            posicao++;
            return ok4;
        } else if(posicao == 5) {
            posicao++;
            return ok5;
        } else if(posicao == 6) {
            posicao++;
            return ok6;
        }
        return null;

    }
    private void montarPalavra()
    {
        foreach (char c in palavra)
        {
            switch (c)

            {
                case 'A':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraA;
                    break;
                case 'B':
                    Debug.Log(letraB);

                    getOk().GetComponent<SpriteRenderer>().sprite = letraB;
                    break;
                case 'C':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraC;
                    break;
                case 'D':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraD;
                    break;
                case 'E':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraE;
                    break;
                case 'F':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraF;
                    break;
                case 'G':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraG;
                    break;
                case 'H':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraH;
                    break;
                case 'I':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraI;
                    break;
                case 'J':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraJ;
                    break;
                case 'K':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraK;
                    break;
                case 'L':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraL;
                    break;
                case 'M':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraM;
                    break;
                case 'N':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraN;
                    break;
                case 'O':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraO;
                    break;
                case 'P':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraP;
                    break;
                case 'Q':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraQ;
                    break;
                case 'R':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraR;
                    break;
                case 'S':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraS;
                    break;
                case 'T':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraT;
                    break;
                case 'U':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraU;
                    break;
                case 'V':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraV;
                    break;
                case 'X':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraX;
                    break;
                case 'Y':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraY;
                    break;
                case 'Z':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraZ;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
        }
    }
    public void addRight()
    {
        right++;
        if (right >= pontos)
        {
            victory();

            coroutine = playVictoryEnum();
            StartCoroutine("playVictoryEnum");
        }
        else
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

    IEnumerator playVictoryEnum()
    {
        yield return new WaitForSecondsRealtime(1f);
        audioController.playFx(audioController.fxPalavra, 1);
        yield return new WaitForSecondsRealtime(0.5f);
        audioController.playFx(audioController.fxVictory, 1);

    }
    public void victory()
    {
        hudGameOver.SetActive(true);
        Debug.Log(" victory ");
        audioController.pauseMusic();
    }
}
