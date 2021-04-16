using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JY_MeditoMap : MonoBehaviour
{
    public void Update()
    {
       
    if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}

