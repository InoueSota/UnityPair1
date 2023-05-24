using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringo : MonoBehaviour
{
    public GameObject ringoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ringo = Instantiate(ringoPrefab, new Vector3(-3.5f,-8f, 0.1f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
