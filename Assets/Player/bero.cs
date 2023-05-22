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
    private bool isHookedcoolTime = false;
        private Vector2 hookTarget; // ターゲットの目標値
    public Vector2 hookPower= new Vector2 (8,8);
    private  new Rigidbody2D rigidbody2D;
    PlayerController player_muki;
    private GameObject Player_;
    public Tilemap tilemap;
    public int muki = 1;
    public GameObject BeroPrefab;
    public float CoolTime=1f;
    private GameObject beroN_;
    private bool beronobita = false;
    // Start is called before the first frame update
    void Start()
    {
        hookSpeed = 30f;
        rigidbody2D=this.GetComponent<Rigidbody2D>();
        CoolTime = 1.0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false)  // K_codeがクリックされたら
        {    
             Vector2 targetPosition = new(player_.transform.position.x+(hookPower.x*muki),player_.transform.position.y+(hookPower.y));
             beroN_ = Instantiate(BeroPrefab,player_.transform);
            var script = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
            HookPlayer(targetPosition);
            script.muki_=muki;  // 値を設定
                isHooked = true;
                isHookedcoolTime = true;     
          
            CoolTime = 1.0f;
        }
        if (beroN_ != null)
        {
            var scriptbero = beroN_.GetComponent<BeroNobiru>();  // プレハブにアタッチされているスクリプトの参照
            if (scriptbero!=null&&scriptbero.turnPoint == true)
            {
                beronobita = true;
                Destroy(scriptbero);
                Destroy(beroN_);
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

        if (isHooked==true && isHookedcoolTime == true&&beronobita==true)
        {           
            MovePlayer();
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
            beronobita = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor"&& CoolTime==0)
        {
            isHookedcoolTime = false;
            isHooked = false;
            beronobita = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor" && CoolTime == 0)
        {
            isHookedcoolTime = false;
            isHooked = false;
            beronobita = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor" && CoolTime == 0)
        {
            isHookedcoolTime = false;
            isHooked = false;
            beronobita = false;
        }
    }

    void SetisHooked(bool b)
    {
        isHooked = b;
    }
}
