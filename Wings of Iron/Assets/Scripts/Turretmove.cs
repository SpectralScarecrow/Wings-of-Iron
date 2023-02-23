using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turretmove : MonoBehaviour
{

    public Transform player;
    public Transform gun;
    public float BHP;

    public float orgrailtme;
    public float railtimer;
[SerializeField]
    float dis;
    public Transform head;
    public float range;
    public GameObject shell;
    public float cooldown;
    public float orgcool;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(player.position, transform.position);
        if(dis <= range && cooldown<= 0)
        {
            head.LookAt(player);
            railtimer-= Time.deltaTime;
        }
        if (railtimer <=0)
        {
            Instantiate(shell, gun.position, transform.rotation);
            railtimer = orgrailtme;
            cooldown = orgcool;
        }
        cooldown -= Time.deltaTime;






    }
}
