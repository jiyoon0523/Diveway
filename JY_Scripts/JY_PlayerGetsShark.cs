using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PlayerGetsShark : MonoBehaviour {
    GameObject alphaShark;
    public Rigidbody rigidAlphaShark;
    float distanceShark;
    public float turnSpeed = 3000;

    // Update is called once per frame
    private void Update() {
        alphaShark = GameObject.Find("JY_AlphaShark");
        rigidAlphaShark = alphaShark.GetComponent<Rigidbody>();
        distanceShark = Vector3.Distance(transform.position, alphaShark.transform.position);

        if (distanceShark < 40 && Input.GetKey(KeyCode.LeftShift)) {
            transform.position = Vector3.Lerp(transform.position, rigidAlphaShark.transform.position, 10 * Time.deltaTime);
            GameObject sharkLabel = GameObject.Find("JY_Blackbg1");
            GameObject sharkLabelText = GameObject.Find("JY_WhenSharkHold");
            sharkLabel.SetActive(true);
            sharkLabelText.SetActive(true);
            if (Input.GetKey(KeyCode.E)) {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            FixedJoint fixedJoint = GetComponent<FixedJoint>();
            Destroy(fixedJoint);
            transform.position = transform.position + Vector3.right * 2;
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
