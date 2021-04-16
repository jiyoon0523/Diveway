using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_CamPos3 : MonoBehaviour
{// 5초동안 약간 아래쪽에서 천천히 플레이어 쪽으로 다가간다
 // 속성: 이동속도 시간

    //public GameObject target;
    public Transform target;
    public float speed = 30;
    public float zoomInTime = 6;
    float currentTime;
   
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(159.78f, 12.66f, 50.78f);
        transform.LookAt(target);

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        Vector3 dir = target.position- transform.position;
        // float distPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (1.5f < currentTime && currentTime < zoomInTime)
        {
            transform.position += dir * speed * 1 * Time.deltaTime;
        }

        else if (currentTime > zoomInTime)
        {
            transform.position = new Vector3(target.position.x, target.position.y + 0.5f, target.position.z - 3f);
        }
        transform.LookAt(target);
    }
    //else if (distPlayer <= 6 && currentTime > zoomInTime && currentTime < 12)
    //{
    //    Transform targetTr = target.GetComponent<Transform>();
    //    //targetTr.eulerAngles = new Vector3(70, 0, -190);
    //    //transform.position = new Vector3(target.transform.position.x+3, target.transform.position.y-10, target.transform.position.z);

    //    transform.position = new Vector3(149.38f, 13.35984f, 36.38f-10);


    //}

    //else if (currentTime2>10 && currentTime2<15)
    //{
    //    //Vector3 sideView = new Vector3(target.transform.position.x+5, target.transform.position.y + 1, target.transform.position.z);
    //    //transform.position = sideView;
    //    //if (transform.position == sideView)

    //    Transform targetTr = target.GetComponent<Transform>();
    //    targetTr.eulerAngles = new Vector3(0,90,0);
    //    Vector3 backView = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z-2);
    //    transform.position = backView;
    //        //transform.position = Vector3.Lerp(transform.position, backView, speed * Time.deltaTime);
    //        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y+0.5f, target.transform.position.z-5);
    //        print(5555);

    //else if (currentTime >= 12 && currentTime <16)
    //{
    //    //Vector3 dir = Vector3.forward;
    //    transform.position = new Vector3(target.transform.position.x, target.transform.position.y-2, target.transform.position.z);

    //}


}
