using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    float hp = 20;
    public Transform firepoint;
    public Transform player;
    public float guntime;
    public float orgtime;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        guntime -= Time.deltaTime;
        if (guntime <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            guntime = orgtime;
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }


    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            hp--;
        }
    }




}
