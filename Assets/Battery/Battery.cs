using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject bulletPrefab;
    public GameObject batteryinstance;
    public GameObject shotPrefab;
    public PlayerController player;

    [SerializeField] Vector3 position;
    [SerializeField] float speed;

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
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity) as GameObject;
            BatteryBullet b = bullet.GetComponent<BatteryBullet>();
            b.Create(speed);

            for (int i = 0; i < 8; i++)
            {
                GameObject shotparticle_ = Instantiate(shotPrefab, position, Quaternion.identity);
                ShotParticle s = shotparticle_.GetComponent<ShotParticle>();
                if (speed > 0)
                {
                    s.Direction(false);
                }
                else
                {
                    s.Direction(true);
                }
            }

            shotSecond = 0;
        }
    }

}