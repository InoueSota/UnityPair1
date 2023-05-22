using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBreak : MonoBehaviour
{

    private Vector2 HitPos;
    [SerializeField] Tilemap blockTilemap;
    private groundcheck player_;
    private RaycastHit2D hit_;

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
        hit_ = Physics2D.Raycast(player_.transform.position, new Vector3(0, -1, 0), 1, LayerMask.GetMask("Floor"));
        if (hit_.collider == null) return;
        var tilePos = blockTilemap.WorldToCell(hit_.point);
        blockTilemap.SetTile(tilePos, null);
    }
}
