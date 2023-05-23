using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed;//プレイヤーの動く速さ
    [SerializeField] PlayerController player_;
    [SerializeField] Goal goal_;
    [SerializeField] GameObject hipdropPrefab;
    [SerializeField] GameObject batteryDeadPrefab;
    [SerializeField] Transform camera_;　//カメラ
   // [SerializeField] float JumpForce=300f;    //ジャンプの力
    [SerializeField] float dropspeed_;
    public groundcheck grondcheck_;
    public Rigidbody2D rbody2D;
    public Battery battery_;
    //private Collision2D collision2D;
    private bool isGround = false;  //地面判定  
    public bool isHipDropActive = false;
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

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)  )  //左に移動する処理    
        {
            player_.transform.position = new Vector3(transform.position.x - MoveSpeed, transform.position.y);
            muki = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))    //右に移動する処理
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

        if (Input.GetKey(KeyCode.H) && !grondcheck_.IsGround() && !isHipDropActive)
        {
            isHipDropActive = true;
        }

        if (isHipDropActive)
        {
            if (grondcheck_.IsGround())
            {
                player_.rbody2D.velocity = Vector3.zero;
                isGround = true;
                isHipDropActive = false;
                for (int i = 0; i < 8; i++)
                {
                    GameObject hipdrop = Instantiate(hipdropPrefab, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                }
            }

            player_.transform.position = new Vector3(transform.position.x, transform.position.y - dropspeed_);
        }

        //if (Input.GetKeyDown(KeyCode.Space) && isGround && !isHipDropActive)
        //{
        //    this.rbody2D.AddForce(transform.up * JumpForce);    //ジャンプの処理
        //    isGround = false;    //ジャンプ回数制限のためのカウント
        //}
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
        camera_.transform.position = new Vector3(player_.transform.position.x,player_.transform.position.y+3f,-10f);
    }
   public int Getmuki()
    {
        return muki;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery" && isHipDropActive == true)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject batteryDead = Instantiate(batteryDeadPrefab, collision.transform.position, Quaternion.identity);
            }
            goal_.clearCount++;
            Destroy(collision.gameObject);
        }
    }

}
