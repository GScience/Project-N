using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkContainer : MonoBehaviour
{
    public Chunk chunk;

    // Start is called before the first frame update
    void Start()
    {
        chunk.ChunkEventChanged += Redraw;
    }

    void Redraw()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
