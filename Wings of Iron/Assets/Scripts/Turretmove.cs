using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretmove : MonoBehaviour
{
    public Transform player;
    public Transform gun;
    public float BHP;
    public Transform weakspot;
    public float orgrailtme;
    public float railtimer;
    public float orgguntime;
    public float guntime;
    public Transform leftgun;
    public Transform rightgun;
    float dis;
    public Transform head;
    public float range;
    public GameObject shell;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(player.position, transform.position);
        if(dis <= range)
        {
            head.LookAt(player);
            railtimer-= Time.deltaTime;
        }
        if (railtimer <=0)
        {
            Instantiate(shell, gun.position, transform.rotation);
            railtimer = orgrailtme;
        }
    }
}
