using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    public int grab = 2; // 0 - release the object, 1 - grab, 2 - do nothing
    public GameObject anim;
    Collider CollidedWith;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>().speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (grab == 1)
        {
            GrabObj();
        }

        if (grab == 0)
        {
            ReleaseObj();   
        }
       // Debug.Log(grab);
    }

    public void GrabObj()
    {
        StartCoroutine(TestCoroutineStart());
    }

    public void ReleaseObj()
    {
        StartCoroutine(TestCoroutineStop());

    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        CollidedWith = other;
        print(other);
    }

    IEnumerator TestCoroutineStart()
    {
        grab = 2;
        anim.GetComponent<Animator>().speed = 1f;
        yield return new WaitForSeconds(1.5f);
        anim.GetComponent<Animator>().speed = 0f;
        if (CollidedWith != null)
        {
            CollidedWith.GetComponent<Rigidbody>().isKinematic = true;
            CollidedWith.transform.parent = this.transform;
        }
    }


    IEnumerator TestCoroutineStop()
    {
        grab = 2;
        anim.GetComponent<Animator>().StartPlayback();
        anim.GetComponent<Animator>().speed = -1f;
        if (CollidedWith != null)
        {
            CollidedWith.transform.parent = null;
            CollidedWith.GetComponent<Rigidbody>().isKinematic = false; //当发生碰撞时，将碰撞到的对象的刚体设置为非静止状态，即受到物理引擎的影响，可以受到外部力的作用，位置和旋转也会根据物理引擎的计算结果更新。

        }
        yield return new WaitForSeconds(3f);//在进行下一步之前等待1.5秒。在这里，协程暂停了1.5秒，然后继续执行。
        anim.GetComponent<Animator>().speed = 0f;
    }
}
