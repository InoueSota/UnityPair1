using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject bulletPrefab;
    public GameObject batteryinstance;
    public PlayerController player;

    [SerializeField] Vector3 position;

    float shotSecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        batteryinstance = Instantiate(batteryPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryinstance != null)
        {
            Shot();
        }
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        shotSecond += Time.deltaTime;
        if (shotSecond > 3)
        {
            GameObject bulllet = Instantiate(bulletPrefab, position, Quaternion.identity) as GameObject;

            shotSecond = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery" && player.isHipDropActive == true)
        {
            Destroy(batteryinstance.gameObject);
        }
    }
}