using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBullet : MonoBehaviour
{
    float speed_;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed_, 0.0f);

        Destroy(this.gameObject, 3.0f);
    }

    public void Create(float speed)
    {
        speed_ = speed;
    }



    private void OnDrawGizmos() //�v���n�u�̓����蔻��`��
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

            // ����2D��Collider�ɑ΂��Ă����l�ɏ�����ǉ����Ă�������
        }
    }
}
