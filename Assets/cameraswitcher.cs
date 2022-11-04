using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitcher : MonoBehaviour
{
    Camera mainCamera;
    Camera combatCamera;

    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        combatCamera = GameObject.Find("Combat Camera").GetComponent<Camera>();
    }
    public void switchCams()
    {
        if (mainCamera.enabled == true) {

            mainCamera.enabled = false;
            combatCamera.enabled = true;
        
        }
        if (combatCamera.enabled == true)
        {

            mainCamera.enabled = true;
            combatCamera.enabled = false;

        }


    }

}