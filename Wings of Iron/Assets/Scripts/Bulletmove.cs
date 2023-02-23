using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    float lifetime = 10;
    public float speed = 60;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(this.gameObject);
        }

    }


}
