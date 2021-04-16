using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_CamPos2 : MonoBehaviour
{
    public GameObject target;
    
    public float dist = 7.0f;
    public float height = 3.0f;
    public float smoothRotate = 5.0f;
    public float speed = 10;

    private Transform tr;

    public float rotSpeed = 5.0f;
    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {
        RotateByMouse();
    }

    void RotateByMouse() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;
        my = Mathf.Clamp(my, -90.0f, 90.0f);

        float x = dist * Mathf.Cos(mx);
        float z = dist * Mathf.Sin(mx);
        float y = dist* Mathf.Tan(my);

        tr.position = new Vector3(target.transform.position.x + x, target.transform.position.y + y, target.transform.position.z + z); 
        tr.LookAt(target.transform);
    }
 }
