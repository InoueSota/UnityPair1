using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BeroNobiru : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerControllerscript;
    private float heightPos;    //�L�т钷�� 
    public bool turnPoint;  //�x�����߂������ǂ���
    public float BeroMoveSpeed;     
    public int muki_;
    public bool Hit_Bullet;     //�x�����e�ɓ����������ǂ���
    public Vector2 TargetPos;   //�����������̂ۂ������
  

    void Start()
    {
        heightPos = 0;
        turnPoint = false;
    
    }

    void Update()
    {
        shinsyuku();

    }

    private void shinsyuku()
    {
        if (transform.localScale.y > 10.0f)
        {
            turnPoint = true;
        }
        else if (transform.localScale.y < 0.0f)
        {
            turnPoint = false;
        }
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y/*+(heightPos*0.01f)*/, this.transform.position.z);

        if (!turnPoint)
        {
            transform.localScale = new Vector3(1, heightPos, 1);
            if (muki_ == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45f);
            }
            else if (muki_ == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45f);

            }
            heightPos += BeroMoveSpeed * Time.deltaTime;
        }
        if (turnPoint)
        {
            transform.localScale = new Vector3(1, heightPos, 1);
            heightPos -= BeroMoveSpeed * Time.deltaTime;
            if (heightPos < 0.0f)
            {
                Destroy(this.gameObject);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Hit_Bullet = true;
            TargetPos= collision.transform.position;
        }
    }

    private void OnDrawGizmos()
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
