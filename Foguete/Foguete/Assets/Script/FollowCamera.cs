using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform TargetToFollow;
    public GameObject bgFixo;
    public GameObject limpaTrilho;
    private float y;
    private GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.currenteState.Equals(GameState.GAMEOVER))
        {

            transform.position = new Vector3(
                transform.position.x,
                Mathf.Clamp(TargetToFollow.position.y, 0f, 500f),
                transform.position.z
                );

            if((TargetToFollow.position.y - 30) > limpaTrilho.transform.position.y)
                limpaTrilho.transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Clamp(TargetToFollow.position.y - 30, 0f, 500f),
                    transform.position.z
                    );
        
            //asteroid.transform.position = new Vector3(transform.position.x, transform.position.y-4, 0);
            y = transform.position.y;
            //bgFixo.transform.position = new Vector3(bgFixo.transform.position.x, transform.position.y, bgFixo.transform.position.z);
        }
    }
}
