using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PlayerMeditate : MonoBehaviour
{
    public GameObject sharkStatue;
    public GameObject sharkStatueTop;
    public float turnSpeed = 2000;
    public float turnTime = 1f;
    float currentTime;
    float distanceStatue;

    // Update is called once per frame
    void Update()
    {
        distanceStatue = Vector3.Distance(transform.position, sharkStatue.transform.position);
        
        if (distanceStatue <= 20)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                transform.position = Vector3.Lerp(transform.position, sharkStatueTop.transform.position, 10 * Time.deltaTime);
            }
        }
    }
}


     