using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private AudioController audioController;
    public GameObject bomb;
    private Animator bombAnimator;

    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        bombAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.tag);
        if (collision.CompareTag("Meteor")) //(collision.name.Equals("asteroid"))
        {

            //Instantiate(ShieldParticle, transform.position, Quaternion.identity);
            //audioController.pauseFxEngine();
            audioController.playFx(audioController.fxExplosion, 1);
            //shield.SetActive(false);
            Destroy(collision.gameObject);
            bombAnimator.SetBool("bum", true);
            Destroy(bomb,1.2f);

        }
       

    }

}
