using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)&& Input.GetKeyDown(KeyCode.K))
        {
            FadeManager.Instance.LoadScene("Stage1", 1.0f);
        }
    }
}
