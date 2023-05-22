using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject bulletPrefab;
    public GameObject batteryinstance;

    float shotSecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        batteryinstance = Instantiate(batteryPrefab, new Vector3(3, 0, 0), Quaternion.identity);
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        shotSecond += Time.deltaTime;
        if (shotSecond > 3)
        {
            GameObject bulllet = Instantiate(bulletPrefab, batteryinstance.transform.position, Quaternion.identity) as GameObject;

            shotSecond = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
}