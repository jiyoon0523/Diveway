using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_InteractBeam : MonoBehaviour
{
    public float speed = 20;
    public float existTime = 0.5f;
    float currentTime;
    public float beamRange = 15;

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("JY_Player");
        transform.LookAt(target.transform.up);

        Vector3 dir = target.transform.up;
        transform.position += dir * speed * Time.deltaTime;

        currentTime += Time.deltaTime;  
        if (currentTime > existTime)
        {
            Destroy(gameObject);
            currentTime = 0;
        }
    }
}
