using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstantiate : MonoBehaviour
{
    public GameObject myPrefabRed, myPrefabGreen, myPrefabBlue;

    void Start()
    {
        //GameObject obj = Instantiate(myPrefabBlue, new Vector3(-3.816f, 3.6f, -4.14f), Quaternion.Euler(0f, 0.962f, 0f));
        //obj.transform.parent = GameObject.Find("base").transform;
    }

    public void InstantiateRed()
    {
        GameObject obj = Instantiate(myPrefabRed, new Vector3(-3.816f, 3.6f, -4.14f),Quaternion.Euler(0f, 0.962f, 0f));
        obj.transform.parent = GameObject.Find("base").transform;
    }

    public void InstantiateGreen()
    {
        GameObject obj = Instantiate(myPrefabGreen, new Vector3(-3.816f, 3.6f, -4.14f),  Quaternion.Euler(0f, 0.962f, 0f));
        obj.transform.parent = GameObject.Find("base").transform;
    }
    public void InstantiateBlue()
    {
        GameObject obj = Instantiate(myPrefabBlue, new Vector3(-3.816f, 3.6f, -4.14f),  Quaternion.Euler(0f, 0.962f, 0f));
        obj.transform.parent = GameObject.Find("base").transform;
        //这一行代码将新创建的游戏对象设置为BaseOrigin对象的子级。
        //GameObject.Find("BaseOrigin")是根据场景中的名称查找对象。
        //transform表示对象的Transform组件，通过将obj的父级设置为BaseOrigin对象，
        //可以使新对象成为BaseOrigin对象的子物体。
    }
}
