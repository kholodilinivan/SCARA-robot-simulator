using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotTest : MonoBehaviour
{
   public GameObject J1;
    //public float J1Angle;
    public float J1Distance;
    public GameObject J2;
    public float J2Angle;
    public GameObject J3;
    public float J3Angle;
    public GameObject J4;
    public float J4Angle;
    public GameObject Blue;
    public GameObject Red ;
    public GameObject Green ;


    public Text  J1string, J2string, J3string, J4string, BlueBox_x, BlueBox_y, BlueBox_z, RedBox_x, RedBox_y, RedBox_z, GreenBox_x, GreenBox_y, GreenBox_z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        J1.transform.localPosition = new Vector3(0, J1Distance, 0);//��ʾY���ϵ�ƫ�����ı���
        //J1.transform.localRotation = Quaternion.AngleAxis(J1Angle, new Vector3(0, 1, 0));
        J2.transform.localRotation = Quaternion.AngleAxis(J2Angle, new Vector3(0, 1, 0));//����ı�����ת����Ϊһ����Y��Ϊ���򣬽Ƕ�ΪJ2Angle����ת��
        J3.transform.localRotation = Quaternion.AngleAxis(J3Angle, new Vector3(0, 1, 0));
        J4.transform.localRotation = Quaternion.AngleAxis(J4Angle, new Vector3(0, 1, 0));

        J1string.text = J1Distance.ToString();
        J2string.text = J2Angle.ToString();
        J3string.text = J3Angle.ToString();
        J4string.text = J4Angle.ToString();

        //������ɫ���ӵ�������ʾ
        Blue = GameObject.Find("CubeBlue(Clone)");
        if (Blue != null)
        {
            Vector3 coordinates = Blue.transform.position;
            BlueBox_x.text = coordinates.x.ToString();
            BlueBox_y.text = coordinates.y.ToString();
            BlueBox_z.text = coordinates.z.ToString();
        }
        else
        {
            BlueBox_x.text = 0.ToString();
            BlueBox_y.text = 0.ToString();
            BlueBox_z.text = 0.ToString();

        }

        Red  = GameObject.Find("CubeRed(Clone)");//����ɫ����������ʾ
        if (Red  != null)
        {
            Vector3 coordinates = Red .transform.position;
            RedBox_x.text = coordinates.x.ToString();
            RedBox_y.text = coordinates.y.ToString();
            RedBox_z.text = coordinates.z.ToString();
        }
        else
        {
            RedBox_x.text = 0.ToString();
            RedBox_y.text = 0.ToString();
            RedBox_z.text = 0.ToString();

        }

        Green  = GameObject.Find("CubeGreen(Clone)");//����ɫ����������ʾ
        if (Green != null)
        {
            Vector3 coordinates = Green.transform.position;
            GreenBox_x.text = coordinates.x.ToString();
            GreenBox_y.text = coordinates.y.ToString();
            GreenBox_z.text = coordinates.z.ToString();
        }
        else
        {
            GreenBox_x.text = 0.ToString();
            GreenBox_y.text = 0.ToString();
            GreenBox_z.text = 0.ToString();

        }
    }
}
