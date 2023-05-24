using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject goalPrefab;
    public int clearCount;
    [SerializeField] int maxClear;
    [SerializeField] string scene;

    // Start is called before the first frame update
    void Start()
    {
        clearCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (clearCount == maxClear)
        {
            FadeManager.Instance.LoadScene(scene, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
