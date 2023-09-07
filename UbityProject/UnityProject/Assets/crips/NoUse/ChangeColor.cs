using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
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
    public  void ChangeCubeColorGreen()
    {
        Renderer cubeRenderer = Cube.GetComponent<Renderer>();
        cubeRenderer.material.color = Color.green;
    }
    public void ChangeCubeColorBlue()
    {
        Renderer cubeRenderer = Cube.GetComponent<Renderer>();
        cubeRenderer.material.color = Color.blue ;
    }
    public void ChangeCubeColorRed()
    {
        Renderer cubeRenderer = Cube.GetComponent<Renderer>();
        cubeRenderer.material.color = Color.red ;
    }
}
