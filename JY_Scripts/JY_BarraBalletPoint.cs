using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_BarraBalletPoint : MonoBehaviour
{
    GameObject player;
    float distPlayer

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("JY_Player");
    }

    // Update is called once per frame
    void Update()
    {
        distPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distPlayer <= 30 && Input.GetKeyUp(KeyCode.E))
        {
            GameObject smB = GameObject.Find("JY_ScoreManager_Ballet");
            JY_ScoreManager_Ballet smb = smB.GetComponent<JY_ScoreManager_Ballet>();
            smb.currentScore++;
            smb.currentScoreUI.text = "Ballet: " + smb.currentScore + "/2";
        }
    }
}
