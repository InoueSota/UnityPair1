using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bero : MonoBehaviour
{
    public Transform player_;
    [SerializeField] float hookSpeed;    //フックのスピード
    public bool isHooked = false;  //引っかかっているかどうか
    public bool isHookedcoolTime = false;
        public Vector2 hookTarget; // ターゲットの目標値
    public Vector2 hookPower= new Vector2 (8,8);
    private  new Rigidbody2D rigidbody2D;
    PlayerController player_muki;
    private GameObject Player_;
    public Tilemap tilemap;
    public int muki = 1;
    public GameObject BeroPrefab;
    public float CoolTime=1f;
    private GameObject beroN_;
   // private bool beronobita = false;
    // Start is called before the first frame update
    void Start()
    {
       
        rigidbody2D=this.GetComponent<Rigidbody2D>();
        CoolTime = 1.0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false&&CoolTime==0)  // K_codeがクリックされたら
        {    
           //  Vector2 targetPosition = new(player_.transform.position.x+(hookPower.x*muki),player_.transform.position.y+(hookPower.y));
             beroN_ = Instantiate(BeroPrefab);
             beroN_.transform.position = player_.transform.position;
            var script = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
            script.muki_=muki;  // 値を設定
            if (script.Hit_Bullet == true)  //べロが弾に当たったら
            {
                
               
            }
            isHooked = true;
            isHookedcoolTime = true;
            CoolTime = 1.0f;
        }

        if (beroN_ != null)
        {
            var scriptbero = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
                HookPlayer(scriptbero.TargetPos);   //当たった場所に引っ張られる
            

            if (scriptbero != null && scriptbero.turnPoint == true) //ベロ消す処理
            {
               
                //Destroy(scriptbero);
                //Destroy(beroN_);
            }
            if (scriptbero.Hit_Bullet==true)
            {
                MovePlayer();   //引っ張られる動き
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            muki = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            muki = 1;
        }

       
        CoolTime -= Time.deltaTime;
        CoolTime = Mathf.Clamp(CoolTime, 0, 1);

       
    }

    void HookPlayer(Vector2 targetpossition)
    {
        hookTarget= targetpossition;    
       
    }

    void MovePlayer()
    {
        player_.transform.position = Vector2.MoveTowards(player_.transform.position, hookTarget, hookSpeed*Time.deltaTime);
        if((Vector2.Distance(hookTarget, player_.transform.position) < 0.1f)) //近くなったらファルス
        {
            isHooked= false;
            Destroy(beroN_);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor"|| CoolTime==0)
        {
            isHookedcoolTime = false;
            isHooked = false;
          
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || CoolTime == 0)
        {
            isHookedcoolTime = false;
            isHooked = false;
         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || CoolTime == 0)
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
