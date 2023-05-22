using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bero : MonoBehaviour
{
    public Transform player_;
    [SerializeField] float hookSpeed;    //�t�b�N�̃X�s�[�h
    public bool isHooked = false;  //�����������Ă��邩�ǂ���
    public bool isHookedcoolTime = false;
        public Vector2 hookTarget; // �^�[�Q�b�g�̖ڕW�l
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
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false&&CoolTime==0)  // K_code���N���b�N���ꂽ��
        {    
           //  Vector2 targetPosition = new(player_.transform.position.x+(hookPower.x*muki),player_.transform.position.y+(hookPower.y));
             beroN_ = Instantiate(BeroPrefab);
             beroN_.transform.position = player_.transform.position;
            var script = beroN_.GetComponent<BeroNobiru>();  // �v���n�u�ɃA�^�b�`����Ă���X�N���v�g�̎Q��
            script.muki_=muki;  // �l��ݒ�
            if (script.Hit_Bullet == true)  //�׃����e�ɓ���������
            {
                
               
            }
            isHooked = true;
            isHookedcoolTime = true;
            CoolTime = 1.0f;
        }

        if (beroN_ != null)
        {
            var scriptbero = beroN_.GetComponent<BeroNobiru>();  // �v���n�u�ɃA�^�b�`����Ă���X�N���v�g�̎Q��
                HookPlayer(scriptbero.TargetPos);   //���������ꏊ�Ɉ���������
            

            if (scriptbero != null && scriptbero.turnPoint == true) //�x����������
            {
               
                //Destroy(scriptbero);
                //Destroy(beroN_);
            }
            if (scriptbero.Hit_Bullet==true)
            {
                MovePlayer();   //���������铮��
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
        if((Vector2.Distance(hookTarget, player_.transform.position) < 0.1f)) //�߂��Ȃ�����t�@���X
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
