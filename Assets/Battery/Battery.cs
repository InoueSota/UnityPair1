using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject bulletPrefab;

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public BatteryBullet bullet;
    }

    [SerializeField] ShotData shotData = new ShotData { frame = 300, bullet = null };

    int shotFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject batteryinstance = Instantiate(batteryPrefab, new Vector3(3,0,0),Quaternion.identity);
        GameObject bulletinstance = Instantiate(bulletPrefab, new Vector3(3, 0, 0), Quaternion.identity);
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            BatteryBullet bullet = (BatteryBullet)Instantiate(shotData.bullet, batteryPrefab.transform.position, Quaternion.identity);

            bullet.SetMoveVec(new Vector3(-1,0,0));

            shotFrame = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
}
