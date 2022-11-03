using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public int ammo;
    public float orgdelay;
    public float delay;
    public GameObject bullet;
    public Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
            if (delay <= 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                delay = orgdelay;
            }
            else
            {
                delay -= Time.deltaTime;
            }
    }
}
