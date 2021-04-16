using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_SharkStatue : MonoBehaviour
{
    public GameObject player;
    public GameObject triangle;

    float distancePlayer;

    bool destroyed = false;

    void Start() {
        player = GameObject.Find("JY_Player");
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distancePlayer <= 15 && destroyed == false)
        {
            triangle.gameObject.SetActive(true);
        }

        if (distancePlayer <= 15 && Input.GetKey(KeyCode.Return))
        {
            Destroy(triangle);
            destroyed = true;

            GameObject smM = GameObject.Find("JY_ScoreManager_Meditate");
            JY_ScoreManager_Meditate smm = smM.GetComponent<JY_ScoreManager_Meditate>();
            smm.currentScore++;
            smm.currentScoreUI.text = "Meditate: " + smm.currentScore + "/1";

        }
    }
}

