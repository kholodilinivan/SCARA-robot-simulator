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
            CollidedWith.GetComponent<Rigidbody>().isKinematic = false; //��������ײʱ������ײ���Ķ���ĸ�������Ϊ�Ǿ�ֹ״̬�����ܵ����������Ӱ�죬�����ܵ��ⲿ�������ã�λ�ú���תҲ�������������ļ��������¡�

        }
        yield return new WaitForSeconds(3f);//�ڽ�����һ��֮ǰ�ȴ�1.5�롣�����Э����ͣ��1.5�룬Ȼ�����ִ�С�
        anim.GetComponent<Animator>().speed = 0f;
    }
}
