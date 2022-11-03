using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerspin : MonoBehaviour
{
    public Vector3 rote;
    public float speed;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rote * speed * Time.deltaTime);
    }
}
