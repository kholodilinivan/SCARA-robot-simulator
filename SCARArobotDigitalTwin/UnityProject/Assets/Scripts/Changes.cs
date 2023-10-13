using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Changes : MonoBehaviour
{
    // Camera Config
    public GameObject DroneConfig;
    public InputField rot_cam_x, rot_cam_y, rot_cam_z;

    // Laser Config
    public GameObject LasActive; 
    public InputField las_pos_x, las_pos_y, las_pos_z, las_rot_x, las_rot_y, las_rot_z;
    public Material LaserMaterial;

    // CV System Config
    public GameObject CVSyst;
    public InputField cv_pos_x, cv_pos_y, cv_rot_z;

    // Checkerboards Config
    public GameObject LeftChess, RightChess, BottomChess;
    public InputField leftchess_pos_x, leftchess_pos_y, leftchess_pos_z, rightchess_pos_x, rightchess_pos_y, rightchess_pos_z,
    leftchess_rot_x, leftchess_rot_y, leftchess_rot_z, rightchess_rot_x, rightchess_rot_y, rightchess_rot_z,
    bottomchess_pos_x, bottomchess_pos_y, bottomchess_pos_z, bottomchess_rot_x, bottomchess_rot_y, bottomchess_rot_z,
    square_dx, square_dy;

    // Obstacles Config
    public GameObject LeftCube, FrontCube, RightCube;
    public InputField leftcube_pos_x, leftcube_pos_y, leftcube_pos_z, leftcube_rot_x, leftcube_rot_y, leftcube_rot_z,
    frontcube_pos_x, frontcube_pos_y, frontcube_pos_z, frontcube_rot_x, frontcube_rot_y, frontcube_rot_z,
    rightcube_pos_x, rightcube_pos_y, rightcube_pos_z, rightcube_rot_x, rightcube_rot_y, rightcube_rot_z;


    void Start()
    {
    }

    void Update()
    {        
    }

    //Camera Config
    // Camera Orientation
    public void DroneXYZ_rot()
    {
        DroneConfig.transform.localRotation = Quaternion.Euler(float.Parse(rot_cam_y.text, CultureInfo.InvariantCulture), float.Parse(rot_cam_z.text, CultureInfo.InvariantCulture), float.Parse(rot_cam_x.text, CultureInfo.InvariantCulture));
    }

    public void Reset_DroneXYZ_rot()
    {
        rot_cam_x.text = "0";
        rot_cam_y.text = "0";
        rot_cam_z.text = "0";
    }

    // Laser Config
    public void LaserToogle(bool newValue)
    {
        LasActive.SetActive(newValue);
    }

    //Laser Position
    public void LaserXYZ()
    {
        LasActive.transform.localPosition = new Vector3((float.Parse(las_pos_y.text, CultureInfo.InvariantCulture))/1000, (float.Parse(las_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(las_pos_x.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_LaserXYZ()
    {
        las_pos_x.text = "0";
        las_pos_y.text = "0";
        las_pos_z.text = "-950";
    }
    // Laser Rotation
    public void LaserXYZ_rot()
    {
        LasActive.transform.localRotation = Quaternion.Euler(float.Parse(las_rot_y.text, CultureInfo.InvariantCulture), float.Parse(las_rot_z.text, CultureInfo.InvariantCulture), float.Parse(las_rot_x.text, CultureInfo.InvariantCulture));
    }
    public void Reset_LaserXYZ_rot()
    {
        las_rot_x.text = "0";
        las_rot_y.text = "0";
        las_rot_z.text = "0";
    }

    // CV System Config
    // Position
    public void CVSystXY()
    {
        CVSyst.transform.localPosition = new Vector3(-(float.Parse(cv_pos_y.text, CultureInfo.InvariantCulture)) / 1000, 0, (float.Parse(cv_pos_x.text, CultureInfo.InvariantCulture)) / 1000);
    }
    public void Reset_CVSystXY()
    {
        cv_pos_x.text = "0";
        cv_pos_y.text = "0";
    }
    // Rotation
    public void CVSyst_rot()
    {
        CVSyst.transform.localRotation = Quaternion.Euler(0, float.Parse(cv_rot_z.text, CultureInfo.InvariantCulture), 0);
    }
    public void Reset_CVSyst_rot()
    {
        cv_rot_z.text = "0";
    }

    // Checkerboards Config
    public void LeftChessToogle(bool newValue)
    {
        LeftChess.SetActive(newValue);
    }
    public void RightChessToogle(bool newValue)
    {
        RightChess.SetActive(newValue);
    }
    public void BottomChessToogle(bool newValue)
    {
        BottomChess.SetActive(newValue);
    }

    // Left pattern position
    public void LeftChessXYZ()
    {
        LeftChess.transform.localPosition = new Vector3((float.Parse(leftchess_pos_x.text, CultureInfo.InvariantCulture))/1000, (float.Parse(leftchess_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(leftchess_pos_y.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_LeftChessXYZ()
    {

        leftchess_pos_x.text = "-675.2";
        leftchess_pos_y.text = "51.8";
        leftchess_pos_z.text = "-416.85";
    }
    // Left pattern Rotation
    public void LeftChessXYZ_rot()
    {
        LeftChess.transform.localRotation = Quaternion.Euler(float.Parse(leftchess_rot_x.text, CultureInfo.InvariantCulture), float.Parse(leftchess_rot_z.text, CultureInfo.InvariantCulture), float.Parse(leftchess_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_LeftChessXYZ_rot()
    {
        leftchess_rot_x.text = "0";
        leftchess_rot_y.text = "0";
        leftchess_rot_z.text = "0";
    }

    // Rigth pattern position
    public void RightChessXYZ()
    {
        RightChess.transform.localPosition = new Vector3((float.Parse(rightchess_pos_x.text, CultureInfo.InvariantCulture))/1000, (float.Parse(rightchess_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(rightchess_pos_y.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_RightChessXYZ()
    {
        rightchess_pos_x.text = "-540.164";
        rightchess_pos_y.text = "1223";
        rightchess_pos_z.text = "-416.85";
    }
    // Right pattern Rotation
    public void RightChessXYZ_rot()
    {
        RightChess.transform.localRotation = Quaternion.Euler(float.Parse(rightchess_rot_x.text, CultureInfo.InvariantCulture), float.Parse(rightchess_rot_z.text, CultureInfo.InvariantCulture), float.Parse(rightchess_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_RightChessXYZ_rot()
    {
        rightchess_rot_x.text = "0";
        rightchess_rot_y.text = "0";
        rightchess_rot_z.text = "0";
    }

    // Bottom pattern position
    public void BottomChessXYZ()
    {
        BottomChess.transform.localPosition = new Vector3((float.Parse(bottomchess_pos_x.text, CultureInfo.InvariantCulture)) / 1000, (float.Parse(bottomchess_pos_z.text, CultureInfo.InvariantCulture)) / 1000, (float.Parse(bottomchess_pos_y.text, CultureInfo.InvariantCulture)) / 1000);
    }
    public void Reset_BottomChessXYZ()
    {
        bottomchess_pos_x.text = "-488";
        bottomchess_pos_y.text = "977";
        bottomchess_pos_z.text = "-1129.735";
    }
    // Right pattern Rotation
    public void BottomChessXYZ_rot()
    {
        BottomChess.transform.localRotation = Quaternion.Euler(float.Parse(bottomchess_rot_x.text, CultureInfo.InvariantCulture), float.Parse(bottomchess_rot_z.text, CultureInfo.InvariantCulture), float.Parse(bottomchess_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_BottomChessXYZ_rot()
    {
        bottomchess_rot_x.text = "0";
        bottomchess_rot_y.text = "0";
        bottomchess_rot_z.text = "0";
    }

// Obstacles Config
    public void LeftCubeToogle(bool newValue)
    {
        LeftCube.SetActive(newValue);
    }
    public void FrontCubeToogle(bool newValue)
    {
        FrontCube.SetActive(newValue);
    }
    public void RightCubeToogle(bool newValue)
    {
        RightCube.SetActive(newValue);
    }

    // Left cube position
    public void LeftCubeXYZ()
    {
        LeftCube.transform.localPosition = new Vector3((float.Parse(leftcube_pos_x.text, CultureInfo.InvariantCulture))/1000, (float.Parse(leftcube_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(leftcube_pos_y.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_LeftCubeXYZ()
    {
        leftcube_pos_x.text = "-922";
        leftcube_pos_y.text = "-158";
        leftcube_pos_z.text = "-680";
    }
    // Left cube Rotation
    public void LeftCubeXYZ_rot()
    {
        LeftCube.transform.localRotation = Quaternion.Euler(float.Parse(leftcube_rot_x.text, CultureInfo.InvariantCulture), float.Parse(leftcube_rot_z.text, CultureInfo.InvariantCulture), float.Parse(leftcube_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_LeftCubeXYZ_rot()
    {
        leftcube_rot_x.text = "0";
        leftcube_rot_y.text = "0";
        leftcube_rot_z.text = "0";
    }

    // Front cube position
    public void FrontCubeXYZ()
    {
        FrontCube.transform.localPosition = new Vector3((float.Parse(frontcube_pos_x.text, CultureInfo.InvariantCulture))/1000, (float.Parse(frontcube_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(frontcube_pos_y.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_FrontCubeXYZ()
    {
        frontcube_pos_x.text = "-843";
        frontcube_pos_y.text = "1799";
        frontcube_pos_z.text = "-680";
    }
    // Front cube Rotation
    public void FrontCubeXYZ_rot()
    {
        FrontCube.transform.localRotation = Quaternion.Euler(float.Parse(frontcube_rot_x.text, CultureInfo.InvariantCulture), float.Parse(frontcube_rot_z.text, CultureInfo.InvariantCulture), float.Parse(frontcube_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_FrontCubeXYZ_rot()
    {
        frontcube_rot_x.text = "0";
        frontcube_rot_y.text = "0";
        frontcube_rot_z.text = "0";
    }

    // Right cube position
    public void RightCubeXYZ()
    {
        RightCube.transform.localPosition = new Vector3((float.Parse(rightcube_pos_x.text, CultureInfo.InvariantCulture))/1000, (float.Parse(rightcube_pos_z.text, CultureInfo.InvariantCulture))/1000, (float.Parse(rightcube_pos_y.text, CultureInfo.InvariantCulture))/1000);
    }
    public void Reset_RightCubeXYZ()
    {
        rightcube_pos_x.text = "521";
        rightcube_pos_y.text = "1158";
        rightcube_pos_z.text = "-680";
    }
    // Right cube Rotation
    public void RightCubeXYZ_rot()
    {
        RightCube.transform.localRotation = Quaternion.Euler(float.Parse(rightcube_rot_x.text, CultureInfo.InvariantCulture), float.Parse(rightcube_rot_z.text, CultureInfo.InvariantCulture), float.Parse(rightcube_rot_y.text, CultureInfo.InvariantCulture));
    }
    public void Reset_RightCubeXYZ_rot()
    {
        rightcube_rot_x.text = "0";
        rightcube_rot_y.text = "0";
        rightcube_rot_z.text = "0";
    }
}
