using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klausur : MonoBehaviour
{
    bool[][][] w;
    // Start is called before the first frame update
    void Start()
    {
        int a = 3, b = 6, c = 2;
        a += c;
        Debug.Log(c);


        b = a * c;
        c++;
        Debug.Log(c);


        b += c * b;
        Debug.Log(b-a);
    }

    // Update is called once per frame
    void Update()
    {
        Start();
       
    }
}
