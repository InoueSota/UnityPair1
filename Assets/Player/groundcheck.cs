using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    private string groundTag = "Floor";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
<<<<<<< HEAD
    public TileBreak Tilebreak_;
    public GameObject bero_;
    private bero beroscript;
=======
    public bero bero_;

>>>>>>> a757e054088951154e9f352aa83c27c44cb41020
    private void Start()
    {
        beroscript = bero_.GetComponent<bero>();
    }
    //接地判定を返すメソッド
    //物理判定の更新毎に呼ぶ必要がある
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
            beroscript.isHooked = false;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
