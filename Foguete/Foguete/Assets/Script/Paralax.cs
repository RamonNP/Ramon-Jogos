using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform    backGround;
    public float parallaxScale;
    public float velocidade;

    public float parallaxY;
    public float bgTargetY;



    public Transform cam;
    public Vector3 previewCamPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        previewCamPosition = cam.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        parallaxY = (previewCamPosition.y - cam.position.y) * parallaxScale;
        bgTargetY = backGround.position.y + parallaxY;

        Vector3 bgPos = new Vector3(backGround.position.x, bgTargetY, backGround.position.z);
        backGround.position = Vector3.Lerp(backGround.position, bgPos, velocidade * Time.deltaTime);

        previewCamPosition = cam.position;
    }
}
