using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipDropParticle : MonoBehaviour
{
    private float lifeTime;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        // ���ł���܂ł̎��Ԃ̐ݒ�
        lifeTime = 0.3f;
        // �c�莞�Ԃ�������
        leftLifeTime = lifeTime;
        // ���݂�Scale���L�^
        defaultScale = transform.localScale * 0.2f;
        // �e�����֔�΂�
        velocity = new Vector3
        (
            Random.Range(-5.0f, 5.0f),
            Random.Range( 0.0f, 2.0f),
            0
        );
    }

    // Update is called once per frame
    void Update()
    {
        // �c�莞�Ԃ��J�E���g�_�E��
        leftLifeTime -= Time.deltaTime;
        // ���W���ړ�
        transform.position += velocity * Time.deltaTime;
        // �c�莞�Ԃɂ�菙�X��Scale������������
        transform.localScale = Vector3.Lerp
        (
            new Vector3(0, 0, 0),
            defaultScale,
            leftLifeTime / lifeTime
        );
        // �c�莞�Ԃ�0�ȉ��ɂȂ�����Q�[���I�u�W�F�N�g������
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
