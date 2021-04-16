using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_SpeciesFromPuddle : MonoBehaviour
{
    public float speed = 5;
    public float createTime = 4;
    float currentTime;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * createTime * Time.deltaTime;

        currentTime += Time.deltaTime;
        if(currentTime> createTime)
        {
            Destroy(gameObject);
        }
    }
}
