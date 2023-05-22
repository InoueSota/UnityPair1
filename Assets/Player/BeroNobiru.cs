using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BeroNobiru : MonoBehaviour
{
    private float heightPos;
    public bool turnPoint;
    public float BeroMoveSpeed;
    public int muki_;
   
    
    void Start()
    {
        heightPos = 0;
        turnPoint = false;
       
    }

    void Update()
    {
      

        if (transform.localScale.y > 5.0f)
        {
            turnPoint = true;
        }
        else if (transform.localScale.y < 0.0f)
        {
            turnPoint = false;
        }

        if (!turnPoint)
        {
            transform.localScale = new Vector3(1, heightPos, 1);
            if (muki_ == -1)
            {
             transform.rotation = Quaternion.Euler(0,0,30f);
            }else if (muki_ == 1) {
                transform.rotation = Quaternion.Euler(0, 0, -30f);

            }
            heightPos += BeroMoveSpeed * Time.deltaTime;
        }
        if (turnPoint)
        {
            transform.localScale = new Vector3(1, heightPos, 1);
            heightPos -= BeroMoveSpeed * Time.deltaTime;
            if (heightPos < 0.0f)
            {
                Destroy(this.gameObject);

            }
        }
        transform.position = new Vector3(this.transform.position.x,heightPos * 0.25f, this.transform.position.z);

    }
}
