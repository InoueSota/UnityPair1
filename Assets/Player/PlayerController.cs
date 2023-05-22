using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed;//プレイヤーの動く速さ
    [SerializeField] PlayerController player_;
    [SerializeField] Transform camera_;　//カメラ
    [SerializeField] float JumpForce=300f;    //ジャンプの力
    public groundcheck grondcheck_;
    private Rigidbody2D rbody2D;
    //private Collision2D collision2D;
    private bool isGround = false;  //地面判定  
    public int muki = -1;

    // Start is called before the first frame update
    void Start()
    {
        //MoveSpeed = 0.0f;
        rbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //OnCollisionFloor(collision2D);
        CameraUpdate();
        isGround = grondcheck_.IsGround();
       // Debug.Log("%d",isGround);

    }

    void Move()
    {

        player_.transform.Rotate(0, 0, 0);
        if (Input.GetKey(KeyCode.A))    //左に移動する処理    
        {
            player_.transform.position = new Vector3(transform.position.x - MoveSpeed, transform.position.y);
            muki = -1;
        }
        if (Input.GetKey(KeyCode.D))    //右に移動する処理
        {
            player_.transform.position = new Vector3(transform.position.x + MoveSpeed, transform.position.y);
            muki = 1;
        }
        //if (Input.GetKey(KeyCode.W))    //上に移動（いらない）
        //{
        //    player_.transform.position = new Vector3(transform.position.x , transform.position.y + MoveSpeed);
        //}
        //if (Input.GetKey(KeyCode.S))    //下に移動（いらない）
        //{
        //    player_.transform.position = new Vector3(transform.position.x , transform.position.y - MoveSpeed);
        //}
        if (Input.GetKeyDown(KeyCode.Space) && this.isGround == true)
        
        {
            this.rbody2D.AddForce(transform.up * JumpForce);    //ジャンプの処理
            isGround = true;    //ジャンプ回数制限のためのカウント
        }
    }

    //private void OnCollisionFloor(Collider2D other)
    //{
    //    if (other.tag == "Floor")
    //    {
    //        isGround = false;
    //    }
    //}

    private void CameraUpdate()
    {
        camera_.transform.position = new Vector3(player_.transform.position.x,player_.transform.position.y,-10f);
    }
   public int Getmuki()
    {
        return muki;
    }
}
