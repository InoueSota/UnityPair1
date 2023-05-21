using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBreak : MonoBehaviour
{

    private Vector2 HitPos;
    [SerializeField] Tilemap blockTilemap;
    private groundcheck player_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            
        TileBreak_();
        }
    }

    private void TileBreak_()
    {
        if (player_ != null) return;
        var tilepos=blockTilemap.WorldToCell(player_.transform.position);
       blockTilemap.SetTile(tilepos, null);
    }
}
