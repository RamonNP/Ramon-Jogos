using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private AudioController audioController;
    public GameObject bomb;
    private Animator bombAnimator;
    private IEnumerator coroutine;
    public bool ativo;

    // Start is called before the first frame update
    void Start()
    {
        
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        bombAnimator = GetComponent<Animator>();
        ativo = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.tag + "ATIVO" + ativo);
        if (collision.CompareTag("Meteor") && ativo) //(collision.name.Equals("asteroid"))
        {

            //Instantiate(ShieldParticle, transform.position, Quaternion.identity);
            //audioController.pauseFxEngine();
            audioController.playFx(audioController.fxExplosion, 1);
            //shield.SetActive(false);
            Destroy(collision.gameObject);
            bombAnimator.SetBool("bum", true);
            //bomb.SetActive(false);
            //Destroy(bomb,1.2f);
            coroutine = WaitAndPrint(1.1f);
            StartCoroutine(coroutine);

        }
       

    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        //while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //bomb.SetActive(false);
            bombAnimator.SetBool("nada", true);
            Debug.Log("ATIVA FALSE");
            ativo = false;
        }
    }
    public void finishBum()
    {
        Debug.Log("ATIVA TRUE");
        ativo = true;
        try
        {
            bombAnimator.SetBool("bum", false);
            bombAnimator.SetBool("nada", false);
        }
        catch
        {
            audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
            bombAnimator = GetComponent<Animator>();
            bombAnimator.SetBool("bum", false);
            bombAnimator.SetBool("nada", false);
        }
    }
}
