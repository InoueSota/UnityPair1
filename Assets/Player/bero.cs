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
    private bool isHookedcoolTime = false;
 
    private Vector2 hookTarget; // �^�[�Q�b�g�̖ڕW�l

    private  new Rigidbody2D rigidbody2D;
    PlayerController player_muki;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        hookSpeed = 30f;
        rigidbody2D=this.GetComponent<Rigidbody2D>();   
        player_muki=GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) == true && isHooked == false && isHookedcoolTime == false)  // �}�E�X�̍��{�^�����N���b�N���ꂽ��
        {    
             Vector2 targetPosition = new(player_.transform.position.x+(10),player_.transform.position.y+(10));
            HookPlayer(targetPosition);
            isHooked = true;
            isHookedcoolTime = true;
        }


        if (isHooked==true && isHookedcoolTime == true)
        {
            MovePlayer();
        }
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHookedcoolTime = false;
          
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Floor")
    //    {
    //        isHookedcoolTime = false;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Floor")
    //    {
    //        isHookedcoolTime = false;
    //    }
    //}

    void SetisHooked(bool b)
    {
        isHooked = b;
    }
}
