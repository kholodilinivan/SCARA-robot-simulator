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
        if (cube != null)
        {
            Destroy(cube);
        }
        GameObject cube2 = GameObject.Find("CubeRed(Clone)");
        if (cube != null)
        {
            Destroy(cube2);
        }
        GameObject cube3 = GameObject.Find("CubeGreen(Clone)");
        if (cube != null)
        {
            Destroy(cube3);
        }
    }
    
}
