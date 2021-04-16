using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Puddle : MonoBehaviour {
    public GameObject player;
    public GameObject eelFactory;
    public GameObject eelPoint1;
    public GameObject triangle;

    bool destroyed = false;
    GameObject player;
    float distancePlayer;

    vois Start() {
        player = GameObject.Find("JY_Player");
    }

    // Update is called once per frame
    void Update() {
        // 플레이어가 일정 범위 안에서 스페이스바를 누르면 물고기를 풀어줌
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distancePlayer <= 15 && destroyed == false) {
            triangle.gameObject.SetActive(true);
        }
        if (distancePlayer <= 15 && Input.GetButtonDown("Jump")) {
            Destroy(triangle);
            destroyed = true;
            GameObject eel1 = Instantiate(eelFactory);
            eel1.transform.position = eelPoint1.transform.position;

            GameObject smR = GameObject.Find("JY_ScoreManager_Release");
            JY_ScoreManager_Release smr = smR.GetComponent<JY_ScoreManager_Release>();
            smr.currentScore++;
            smr.currentScoreUI.text = "Release: " + smr.currentScore + "/3";
        }
    }
}
