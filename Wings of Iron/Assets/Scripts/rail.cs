using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class rail : MonoBehaviour
{
    public Transform[] nodes;


    // Start is called before the first frame update
    void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }

   // private void OnDrawGizmos()
    //{
      //  for (int i =0; i< nodes.Length-1; i++)
      //  {
          //  Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
       // }
  //  }

    public Vector3 LinearPosition(int seg, float ratio)
    {
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[seg + 1].position;
        return Vector3.Lerp(p1, p2, ratio);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
