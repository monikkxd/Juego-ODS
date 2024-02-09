using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringupsettings : MonoBehaviour
{
    public GameObject setting;
    public bool issettingactive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (issettingactive == false)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        setting.SetActive(true);
        issettingactive = true;
        this.GetComponent<MouseLook>().enabled = false;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        setting.SetActive(false);
        issettingactive = false;
        this.GetComponent<MouseLook>().enabled = true;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("resume");
    }
}