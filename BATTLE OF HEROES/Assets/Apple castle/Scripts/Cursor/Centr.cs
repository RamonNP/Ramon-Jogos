using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centr : MonoBehaviour {

    public float distance = 10f;
    public bool Go = false;

	void Start () {
		
	}

    void Update()
    {

        if (Input.GetMouseButton(1) && Go == false)
        {
            Go = true;
        }
        else
        {
            Go = false;
        }

        if (Go == true)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
            transform.position = objPosition; // и собственно объекту записываються координаты
        }
    }
}
