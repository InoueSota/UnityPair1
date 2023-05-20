using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryPrefab;

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public BatteryBullet bullet;
    }

    [SerializeField] ShotData shotData = new ShotData { frame = 60, bullet = null };

    int shotFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject batteryinstance = Instantiate(batteryPrefab, new Vector3(3,0,0),Quaternion.identity);
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            BatteryBullet bullet = Instantiate(shotData.bullet, transform.position, Quaternion.identity);
            bullet.SetMoveVec(Quaternion.AngleAxis(0, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));

            shotFrame = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
}
