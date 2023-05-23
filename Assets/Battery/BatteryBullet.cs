using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBullet : MonoBehaviour
{
    float speed_;
    float lifeTime_;
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed_, 0.0f);

        lifeTime_ += Time.deltaTime;

        if (lifeTime_ >= 3.0f)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject batteryDead = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }

    }

    public void Create(float speed)
    {
        speed_ = speed;
    }



    private void OnDrawGizmos() //プレハブの当たり判定描画
    {
        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;

            if (collider is BoxCollider2D boxCollider)
            {
                Gizmos.DrawWireCube(boxCollider.offset, boxCollider.size);
            }
            else if (collider is CircleCollider2D circleCollider)
            {
                Gizmos.DrawWireSphere(circleCollider.offset, circleCollider.radius);
            }

            // 他の2DのColliderに対しても同様に処理を追加してください
        }
    }
}
