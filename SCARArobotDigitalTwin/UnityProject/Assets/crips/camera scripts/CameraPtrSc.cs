using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class CameraPtrSc : MonoBehaviour
{
    public string cameraName;
    public Camera cam;
    public RawImage source;
    //If you need to pull the picture from the camera
    public RenderTexture cameraRender { get; private set; }

    [Header("Save to file")]
    public bool saveToFile;
    //If the build is il2cpp, it will not work to save to the disk where windows is installed
    public string folder;
    public string nameFile;

    public int Height = 980;
    public int Width = 980;
    byte[] encodedPng;
    bool screenshotDone;
    public int x, y;

    string CompleteFilePath;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = GetComponent<Camera>();
            if (cam == null)
                cam = Camera.main;
        }

        cameraRender = new RenderTexture(Width + x, Height + y, 16);
        cam.targetTexture = cameraRender;
        source.texture = cameraRender;
        cam.aspect = 1;
    }

    private void OnEnable()
    {
        CameraController.AddCamera(this);
    }

    private void OnDisable()
    {
        CameraController.RemoveCamera(this);
    }

    private void OnDestroy()
    {
        CameraController.RemoveCamera(this);
    }

    public void CaptureImage()
    {
        screenshotDone = false;
        StartCoroutine(GetRender());
    }

    public bool CaptureDone()
    {
        return screenshotDone;
    }

    public byte[] GetPrtSc()
    {
        screenshotDone = false;
        return encodedPng;
    }

    public void CaptureImage(string FilePath, string Filename, string CameraSelect)
    {
        CompleteFilePath = FilePath + "/" + Filename;
        Debug.Log("File was Saved at:" + CompleteFilePath + ".png");
        StartCoroutine(GetRender());
    }

    IEnumerator GetRender()
    {
        yield return new WaitForEndOfFrame();//在帧结束后暂停代码的执行，以确保在截图之前所有的渲染工作已经完成
        Texture2D tempTex = new Texture2D(Width, Height, TextureFormat.RGB24, false);//创建一个临时的 2D 纹理对象，用于存储截图的像素数据。
        cam.Render();//将相机的渲染结果渲染到屏幕上。
        RenderTexture.active = cameraRender;//设置当前活动的渲染贴图为 cameraRender，即将相机渲染的结果渲染到 cameraRender
        tempTex.ReadPixels(new Rect(x, y, Width, Height), 0, 0);//从屏幕上读取像素数据，范围为给定的矩形区域。
        tempTex.Apply();//设置纹理应用所有的更改。
        //RenderTexture.active = null;
        encodedPng = tempTex.EncodeToPNG();//将纹理转换为 PNG 格式的字节数组。
        Destroy(tempTex);//释放临时纹理对象。
        if (saveToFile)//如果设置为保存到文件，则执行以下代码块。
        {
            try
            {
                File.WriteAllBytes(CompleteFilePath + ".png", encodedPng);//将 PNG 字节数组写入文件，保存为 PNG 图像文件。
                Debug.Log($"[File SAVE]{folder}.png");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        //
        //
        yield return null;
        cameraRender.Release();//释放当前的渲染贴图。
        cameraRender = new RenderTexture(Width + x, Height + y, 16);//创建一个新的渲染贴图，大小为给定的宽度和高度加上偏移量。
        cam.targetTexture = cameraRender;//将相机的目标渲染贴图设置为新创建的渲染贴图。
        source.texture = cameraRender;//将截图显示在游戏场景中的一个 UI 图像上。
        screenshotDone = true;//设置一个标志位，表示截图完成。
    }
}
