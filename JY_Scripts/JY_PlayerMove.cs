using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PlayerMove : MonoBehaviour
{
    public float basicspeed = 10;
    public float boostspeed = 25;
    public float rotspeed = 50;

    public float amp = 2;
    public float amp2 = 2; 
    public float floatSpeed = 2;
    float cTime;

    public GameObject sharkStatue;
    public GameObject puddle1;
    public GameObject puddle2;
    public GameObject puddle3;

    public GameObject beamFactory;
    public GameObject beamPoint;
    public float beamRange = 15;
    public GameObject interactBeam;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //시작할 때, 화면에 없다가 앞으로 헤엄쳐 나와 맵의 끝부분에 위치하게 됨
        transform.position = new Vector3(149.38f, 13.35984f, 36.2f);

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JY_GameManager.Instance.isIntro)
        {
            return;
        }

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            anim.SetInteger("idleToSwim", 1);
        }
        else
        {
            anim.SetInteger("swimToIdle", -1);
        }

        //사용자의 입력을 받아 플레이어를 회전- 캐릭터컨트롤러 이용

        transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal")) * rotspeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxis("Vertical"), 0, 0) * rotspeed * Time.deltaTime); 
        
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
        }

        if (Input.GetMouseButton(1))
        {
            GetComponent<CharacterController>().Move(transform.up * basicspeed * Time.deltaTime);
            Vector3 dir = Vector3.up;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<CharacterController>().Move(transform.up * boostspeed * 2 * Time.deltaTime);
            Vector3 dir = Vector3.up;
        }

        if (Input.GetButtonDown("Jump"))
        {
            GameObject beam = Instantiate(beamFactory);
            beam.transform.position = beamPoint.transform.position;
        }

        float distanceSharkStatue = Vector3.Distance(transform.position, sharkStatue.transform.position);
        float distancePuddle1 = Vector3.Distance(transform.position, puddle1.transform.position);
        float distancePuddle2 = Vector3.Distance(transform.position, puddle2.transform.position);
        float distancePuddle3 = Vector3.Distance(transform.position, puddle3.transform.position);

        if (distanceSharkStatue <= beamRange || distancePuddle1 <= beamRange || distancePuddle2 <= beamRange || distancePuddle3 <= beamRange)
        {
            interactBeam.SetActive(false);
        }
        else
        {
            interactBeam.SetActive(true);
        }
    }

    public float rotSpeed = 5;
    bool isRotate = false;
    float currentAngle;

    private void RotateFull()
    {
        // 1. 키를 누름
        if (Input.GetKeyDown(KeyCode.E))
        {
            //2. 회전중
            if (isRotate)
            {
                // 3. 각도 증가
                currentAngle += rotspeed * Time.deltaTime;
            }
        }
    }

    private void FloatPlayer()
    {
        cTime += Time.deltaTime;
        float y = amp * Mathf.Sin(cTime * floatSpeed); 
        float z = amp2 * Mathf.Cos(cTime * floatSpeed); 
    }
}
