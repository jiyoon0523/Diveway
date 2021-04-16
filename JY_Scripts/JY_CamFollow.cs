using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JY_CamFollow: MonoBehaviour
{
    public Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;

    private Transform tr;

    static bool isCamPos1 = false;
    static bool isCamPos2 = false;

    public GameObject swimUI;
    public GameObject boostUI;
    public GameObject turnUI;

    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        tr.position = target3.position;
    }

    enum CameraState
    {
        Intro,
        Tutorial,
        Play
    }
    CameraState state;

    void Update()
    {
        print("state : " + state);
        switch (state)
        {
            case CameraState.Intro:
                Intro();
                break;
            case CameraState.Tutorial:
                Tutorial();
                break;
            case CameraState.Play:
                Play();
                break;
        }
    }

    // 씬 전환 후 6초동안 멀리서 줌인
    // 일정시간 기다렸다가 상태를 Tutorial로 전환
    private void Intro()
    {
        currentTime += Time.deltaTime;
        transform.position = target3.transform.position;
        if (currentTime > 6)
        {
            state = CameraState.Tutorial;
        }
    }

    bool isSwimUIState = true;
    bool isBoostUIState = false;
    bool isTurnUIState = false;

    // 6초 경과하면 target1위치로 변경, 상태는 Play로 전환
    private void Tutorial()
    {
        JY_GameManager.Instance.isIntro = false;
        transform.position = Vector3.Lerp(transform.position, target1.position, 5 * Time.deltaTime);
        transform.forward = Vector3.Lerp(transform.forward, target1.forward, 5 * Time.deltaTime);
        // 1. Swim UI 나오도록 대기 중인 상태니? true, false
        if (isSwimUIState == true)
        {
            // currentTime 흐르도록 함
            // 만약 경과시간이 6초 를 초과하면 holdUI를 활성화시키기
            // 만약 holdUI 가 비활성화 되어 있으면 
            // 시간 체크해서 활성화 시키기
            if (swimUI.activeSelf == false)
            {
                currentTime += Time.deltaTime;

                if (currentTime > 6)
                {
                    // 그리고 사용자가 버튼을 누르면 Swim UI 보여주는 상태로 전환
                    swimUI.SetActive(true);
                }
            }
            else
            { 
                if (Input.GetMouseButton(1))
                {
                    Destroy(swimUI.gameObject);
                    isSwimUIState = false;
                    isBoostUIState = true;
                    currentTime = 0;
                }
            }
        }
        // Boost UI 가 나오도록 대기중인 상태
        else if (isBoostUIState == true)
        {
            if (boostUI.activeSelf == false)
            {
                currentTime += Time.deltaTime;

                if (currentTime > 3)
                {
                    boostUI.SetActive(true);
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    Destroy(boostUI.gameObject);
                    isBoostUIState = false;
                    isTurnUIState = true;
                    currentTime = 0;
                }
            }

        }
        // Turn UI 가 나오도록 대기중인 상태
        else if (isTurnUIState == true)
        {
            if (turnUI.activeSelf == false)
            {
                currentTime += Time.deltaTime;
                if (currentTime > 1)
                {
                    turnUI.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Destroy(turnUI.gameObject);
                    state = CameraState.Play;
                }
            }
        }
    }

    // 1. target3 에서 시작해서 7초 동안 대기, 이때 플레이어 동작 못함
    // 2. 7초 후 target1 으로 위치하여 튜토리얼 시작, UI 나오기 전까지 해당 동작 못함
    // 3. 튜토리얼
    // 4. 플레이 시작
    // 플레이 중:
    // target2일 때 우클릭을 하면 3초뒤 부드럽게 taret1으로 감
    // target1일 때 우클릭을 하면 그대로 target1에 있음
    // target1일 때 마우스를 움직이면 target2에 있음
    // target2일 때 마우스를 움직이면 그대로 target2에 있음
    private void Play()
    {
        JY_GameManager.Instance.isIntro = false;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.position = Vector3.Lerp(transform.position, target1.position, 2 * Time.deltaTime);
        transform.forward = Vector3.Lerp(transform.forward, target1.forward, 2 * Time.deltaTime);
    }
}
