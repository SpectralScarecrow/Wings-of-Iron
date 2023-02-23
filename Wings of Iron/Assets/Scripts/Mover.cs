using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public rail Rail;
    private int curseg;
    public float transition;
    public bool done;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            Play();
        }
    }


    private void Play()
    {
        transition += Time.deltaTime * 1/3f;
        if (transition > 1)
        {
            transition = 0;
            curseg++;
        }
        if (curseg+1==Rail.nodes.Length)
        {
            transform.position = Rail.nodes[0].position;
            curseg =0;
        }
        transform.position = Rail.LinearPosition(curseg, transition);
    }

}
