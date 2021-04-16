using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_TrianglePopUP : MonoBehaviour
{
    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
       

     
    

