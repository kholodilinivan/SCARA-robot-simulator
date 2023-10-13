using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Reset : MonoBehaviour
{

    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        GameObject cube = GameObject.Find("CubeBlue(Clone)");
        
        GameObject cube2 = GameObject.Find("CubeRed(Clone)");
        
        GameObject cube3 = GameObject.Find("CubeGreen(Clone)");

        Destroy(cube);
        
        Destroy(cube2);
        Destroy(cube3);
        
    }
    
}
