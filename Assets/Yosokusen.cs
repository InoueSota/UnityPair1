using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yosokusen : MonoBehaviour
{
    public GameObject Bero_;   
    private bero beroscript;
    public float Length;
   private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        beroscript = Bero_.GetComponent<bero>();
        spriteRenderer= this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (beroscript.isHooked == false && beroscript.isHookedcoolTime == false && beroscript.CoolTime == 0)
        {
            spriteRenderer.enabled = true;

        }
        else
        {
            spriteRenderer.enabled = false;

        }

        transform.position = beroscript.transform.parent.position;
        if (beroscript.muki == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45f);
            transform.position = new Vector3(this.transform.position.x - (Length * 0.4f), this.transform.position.y + (Length * 0.4f), this.transform.position.z);

        }
        if (beroscript.muki == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45f);
            transform.position = new Vector3(this.transform.position.x + (Length * 0.4f), this.transform.position.y + (Length * 0.4f), this.transform.position.z);

        }
    }
}
