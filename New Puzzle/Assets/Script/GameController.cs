using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int right;
    private int wrong;
    // Start is called before the first frame update
    void Start()
    {
        right = 0;
        wrong = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addRight()
    {
        right++;
    }
    public void addWrongt()
    {
        wrong++;
    }
}
