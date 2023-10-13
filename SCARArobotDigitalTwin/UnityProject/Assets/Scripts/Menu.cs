using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject BtnSimulation, BtnCalib, PanelSimulation, PanelCalib, BtnReset, BtnQuit, FrontCam;

    void Start()
    {
        BtnSimulation.SetActive(false);
        BtnCalib.SetActive(true);
        BtnReset.SetActive(true);
        BtnQuit.SetActive(true);
        PanelSimulation.SetActive(true);
        PanelCalib.SetActive(false);
        GameObject.Find("Front Camera").GetComponent<CameraOperate>().enabled = false;
    }

    void Update()
    {
        
    }

    public void ClickCalib()
    {        
        BtnSimulation.SetActive(true);
        BtnCalib.SetActive(false);
        BtnReset.SetActive(false);
        BtnQuit.SetActive(false);
        PanelSimulation.SetActive(false);
        PanelCalib.SetActive(true);
        GameObject.Find("Front Camera").GetComponent<CameraOperate>().enabled = true;
    }

    public void ClickSimulation()
    {
        BtnSimulation.SetActive(false);
        BtnCalib.SetActive(true);
        BtnReset.SetActive(true);
        BtnQuit.SetActive(true);
        PanelSimulation.SetActive(true);
        PanelCalib.SetActive(false);
        GameObject.Find("Front Camera").GetComponent<CameraOperate>().enabled = false;
        FrontCam.transform.localRotation = Quaternion.Euler(90, 0, 90);
        FrontCam.transform.localPosition = new Vector3(0, 0, 0);
    }
   
    public void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
    
    public void OpenWebSite()
    {
        Application.OpenURL("https://github.com/kholodilinivan/CVSystem");
    }
}
