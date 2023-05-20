using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        float add_move = moveSpeed * Time.deltaTime;
        transform.Translate(moveVec * add_move);
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    public void SetMoveVec(Vector3 _vec)
    {
        moveVec = _vec.normalized;
    }
}
