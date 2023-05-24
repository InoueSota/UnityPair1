using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Unity.VisualScripting.Member;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bero : MonoBehaviour
{
    public Transform player_;
    [SerializeField] float hookSpeed;    //フックのスピード
    [SerializeField] float hookPower;    //フック_pawa-
    public bool isHooked = false;  //引っかかっているかどうか
    public bool isHookedcoolTime = false;
    public Vector2 hookTarget; // ターゲットの目標値
    public Vector2 StartPosition; //押したときのポジション
  
    //public Vector2 hookPower= new Vector2 (8,8);
    private  new Rigidbody2D rigidbody2D;
    PlayerController player_muki;
    private GameObject Player_;
    public Tilemap tilemap;
    public int muki = 1;
    public GameObject BeroPrefab;
    public float CoolTime=1f;
    private GameObject beroN_;
    private bool isTargetPos=false;
   // private float angle;//射出角度
    private Vector2 force;
   // private bool beronobita = false;
    // Start is called before the first frame update
    void Start()
    {
       
        rigidbody2D= player_.GetComponent<Rigidbody2D>();
        CoolTime = 1.0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false&&CoolTime==0)  // K_codeがクリックされたら
        {
          //  rigidbody2D.velocity = Vector2.zero;
            Destroy(beroN_);    //あったら削
            //  Vector2 targetPosition = new(player_.transform.position.x+(hookPower.x*muki),player_.transform.position.y+(hookPower.y));
            beroN_ = Instantiate(BeroPrefab);   //ベロ生成
            StartPosition = player_.transform.position;
            var script = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
            script.muki_=muki;  // 値を設定
            if (script.Hit_Bullet == true)  //べロが弾に当たったら
            {
                 HookPlayer(script.TargetPos);   //当たった場所に引っ張られるポジション
            }
            isHooked = true;
            isTargetPos = false;
            CoolTime = 1.0f;
        }

        if (beroN_ != null)
        {
            beroN_.transform.position = player_.transform.position;
            var scriptbero = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
            if (scriptbero.Hit_Bullet == true)
            {
                if (isTargetPos == false)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    isTargetPos = true;
                }
                else
                {
                 HookPlayer(scriptbero.TargetPos);   //当たった場所に引っ張られるポジション
                Vector2 direction = scriptbero.TargetPos - StartPosition;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             
                 force = Quaternion.Euler(0, 0, angle) * Vector2.right * hookPower;

                }
                rigidbody2D.AddForce(new Vector2(force.x*0.5f,force.y)*Time.deltaTime, ForceMode2D.Impulse);
            }
            if (isHooked == true && isHookedcoolTime == false)
            {             

                isHookedcoolTime = true;
            }


            if (scriptbero != null && scriptbero.turnPoint == true) //ベロ消す処理
            {

                //Destroy(scriptbero);
                //Destroy(beroN_);
            }
            if (scriptbero.Hit_Bullet == true)
            {
                MovePlayer();   //引っ張られる動き
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
            {
                muki = -1;
               // angle = -45f;
                force = new Vector2(-1.0f,1.0f);
              
            }
            if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
            {
                muki = 1;
                //angle = +45f;
                force = new Vector2(1.0f,1.0f);
                

            }
            

        }

       

        CoolTime -= Time.deltaTime;
        CoolTime = Mathf.Clamp(CoolTime, 0, 1);
        if (CoolTime == 0)
        {
            isHookedcoolTime = false;
            isHooked = false;
        }

    }

    void HookPlayer(Vector2 targetpossition)
    {
        Vector2 tmp = new Vector2(0, 0);
        hookTarget= (targetpossition+tmp);    
       
    }

    void MovePlayer()
    {
           // rigidbody2D.AddForce((force * 3.5f), ForceMode2D.Force);
        if ((Vector2.Distance(hookTarget, player_.transform.position) < 0.5f)) //近くなったらファルス
        {
            //CoolTime = 0;
            //isHooked = false;
            //isHookedcoolTime = false;
            isTargetPos = true;
            Destroy(beroN_);
            //Vector2 speed = force*10.0f; // 加速の強さを調整する場合は適宜変更してください
           
        }
        else
        {
             player_.transform.position = Vector2.MoveTowards(player_.transform.position, hookTarget, (hookSpeed * Time.deltaTime));

        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHookedcoolTime = false;
            isHooked = false;
          
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor" )
        {
            isHookedcoolTime = false;
            isHooked = false;
         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHookedcoolTime = false;
            isHooked = false;
           
        }
    }

    void SetisHooked(bool b)
    {
        isHooked = b;
    }
}
