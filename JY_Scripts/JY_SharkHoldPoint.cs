using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_SharkHoldPoint : MonoBehaviour
{
    GameObject sofShark1;

    // Start is called before the first frame update
    void Start()
    {
        sofShark1 = GameObject.Find("SofShark1");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sofShark1.transform.position;
    }
}
