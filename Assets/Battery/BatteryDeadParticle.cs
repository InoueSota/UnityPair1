using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDeadParticle : MonoBehaviour
{
    private float lifeTime;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        // 消滅するまでの時間の設定
        lifeTime = 0.4f;
        // 残り時間を初期化
        leftLifeTime = lifeTime;
        // 現在のScaleを記録
        defaultScale = transform.localScale * 0.6f;
        // 各方向へ飛ばす
        float maxVelocity = 5.0f;
        velocity = new Vector3
        (
            Random.Range(-maxVelocity, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity),
            0
        );
    }

    // Update is called once per frame
    void Update()
    {
        // 残り時間をカウントダウン
        leftLifeTime -= Time.deltaTime;
        // 座標を移動
        transform.position += velocity * Time.deltaTime;
        // 残り時間により徐々にScaleを小さくする
        transform.localScale = Vector3.Lerp
        (
            new Vector3(0, 0, 0),
            defaultScale,
            leftLifeTime / lifeTime
        );
        // 残り時間が0以下になったらゲームオブジェクトを消滅
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
