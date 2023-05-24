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
    [SerializeField] float hookSpeed;    //�t�b�N�̃X�s�[�h
    [SerializeField] float hookPower;    //�t�b�N_pawa-
    public bool isHooked = false;  //�����������Ă��邩�ǂ���
    public bool isHookedcoolTime = false;
    public Vector2 hookTarget; // �^�[�Q�b�g�̖ڕW�l
    public Vector2 StartPosition; //�������Ƃ��̃|�W�V����
  
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
   // private float angle;//�ˏo�p�x
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
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false&&CoolTime==0)  // K_code���N���b�N���ꂽ��
        {
          //  rigidbody2D.velocity = Vector2.zero;
            Destroy(beroN_);    //���������
            //  Vector2 targetPosition = new(player_.transform.position.x+(hookPower.x*muki),player_.transform.position.y+(hookPower.y));
            beroN_ = Instantiate(BeroPrefab);   //�x������
            StartPosition = player_.transform.position;
            var script = beroN_.GetComponent<BeroNobiru>();  // �v���n�u�ɃA�^�b�`����Ă���X�N���v�g�̎Q��
            script.muki_=muki;  // �l��ݒ�
            if (script.Hit_Bullet == true)  //�׃����e�ɓ���������
            {
                 HookPlayer(script.TargetPos);   //���������ꏊ�Ɉ���������|�W�V����
            }
            isHooked = true;
            isTargetPos = false;
            CoolTime = 1.0f;
        }

        if (beroN_ != null)
        {
            beroN_.transform.position = player_.transform.position;
            var scriptbero = beroN_.GetComponent<BeroNobiru>();  // �v���n�u�ɃA�^�b�`����Ă���X�N���v�g�̎Q��
            if (scriptbero.Hit_Bullet == true)
            {
                if (isTargetPos == false)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    isTargetPos = true;
                }
                else
                {
                 HookPlayer(scriptbero.TargetPos);   //���������ꏊ�Ɉ���������|�W�V����
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


            if (scriptbero != null && scriptbero.turnPoint == true) //�x����������
            {

                //Destroy(scriptbero);
                //Destroy(beroN_);
            }
            if (scriptbero.Hit_Bullet == true)
            {
                MovePlayer();   //���������铮��
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
        if ((Vector2.Distance(hookTarget, player_.transform.position) < 0.5f)) //�߂��Ȃ�����t�@���X
        {
            //CoolTime = 0;
            //isHooked = false;
            //isHookedcoolTime = false;
            isTargetPos = true;
            Destroy(beroN_);
            //Vector2 speed = force*10.0f; // �����̋����𒲐�����ꍇ�͓K�X�ύX���Ă�������
           
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
