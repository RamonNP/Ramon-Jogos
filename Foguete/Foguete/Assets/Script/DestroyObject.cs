using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private Transform targetToFollow;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        targetToFollow = Camera.main.transform;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Meteor")) //(collision.name.Equals("asteroid"))
        {
            Destroy(collision.gameObject);

        }
        if (collision.CompareTag("Eixo")) //(collision.name.Equals("asteroid"))
        {
            Destroy(collision.gameObject);

        }
        if (collision.CompareTag("Nave")) //(collision.name.Equals("asteroid"))
        {
            gameController.gameOver(0);

        }
    }
    
}
