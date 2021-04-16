using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PlayerGetsBarracuda : MonoBehaviour {
    GameObject alphaBarra;
    public Rigidbody rigidAlphaBarra;
    float distanceBarra
    public float turnSpeed = 3000;

    // Update is called once per frame
    private void Update() {
        alphaBarra = GameObject.Find("JY_AlphaBarracuda");
        rigidAlphaBarra = alphaBarra.GetComponent<Rigidbody>();
        distanceBarra = Vector3.Distance(transform.position, alphaBarra.transform.position);

        if (distanceBarra < 40 && Input.GetKey(KeyCode.LeftShift)) {
            transform.position = Vector3.Lerp(transform.position, rigidAlphaBarra.transform.position, 10 * Time.deltaTime);
            GameObject barraLabel = GameObject.Find("JY_Blackbg2");
            GameObject barraLabelText = GameObject.Find("JY_WhenFishHold");
            barraLabel.SetActive(true);
            barraLabelText.SetActive(true);
            if (Input.GetKey(KeyCode.E)) {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Rigidbody>() != null) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            }
        }
    }
 