using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial 상태를 만들기
//일정시간 기다린 후 순차적으로 play 키가 적용되도록 함
//속성: 일정시간, 경과시간
//Tutorial UI 띄움

public class JY_GameManager : MonoBehaviour
{
    public float introTime= 6;
    public bool isIntro = true;
    public static JY_GameManager Instance;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isIntro==false)
        {
            return; 
        }
    }
}
