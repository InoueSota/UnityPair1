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
    private bool isHooked = false;  //引っかかっているかどうか
    private Vector2 hookTarget; // ターゲットの目標値

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
        if (Input.GetKeyDown(KeyCode.K)==true&&isHooked==false)  // マウスの左ボタンがクリックされたら
        {    
             Vector2 targetPosition = new(player_.transform.position.x+(10),player_.transform.position.y+(10));
            HookPlayer(targetPosition);
        }


        if (isHooked==true)
        {
            MovePlayer();
        }
    }

    void HookPlayer(Vector2 targetpossition)
    {
        hookTarget= targetpossition;    
        isHooked = true;
    }

    void MovePlayer()
    {
        player_.transform.position = Vector2.MoveTowards(player_.transform.position, hookTarget, hookSpeed*Time.deltaTime);
        if((Vector2.Distance(hookTarget, player_.transform.position) < 0.1f)) //近くなったらファルス
        {
            isHooked= false;    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHooked = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHooked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isHooked = false;
        }
    }


}
