using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hipdrop : MonoBehaviour
{
    [SerializeField] PlayerController player_;
    [SerializeField] float dropspeed_;
    public groundcheck grondcheck_;

    bool isHipDropActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HipDrop();
    }

    private void HipDrop()
    {
        if (Input.GetKey(KeyCode.H) && !grondcheck_.IsGround())
        {
            isHipDropActive = true;
        }

        if (isHipDropActive)
        {
            player_.transform.position = new Vector3(transform.position.x, transform.position.y - dropspeed_);

            if (grondcheck_.IsGround())
            {
                isHipDropActive = false;
            }
        }
    }
}
