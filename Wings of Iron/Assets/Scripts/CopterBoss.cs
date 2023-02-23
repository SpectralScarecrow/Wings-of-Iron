using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopterBoss : MonoBehaviour
{
    public Transform player;
    public Transform fire1;
    public Transform fire2;
    public Transform fire3;
    public GameObject ammo;
    public ParticleSystem ds;

    public int hp;

    public float shoottimer;
    public float movetimer;
    public float bursttimer;
    public float orgtime1;
    public float orgtime2;
    public float orgtime3;
    [SerializeField]
    float speed;

    public Vector2 targetloc;
    [SerializeField]
    float xmax, xmin, ymax, ymin;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        ds.Pause();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(movetimer<= 0)
        {
            transform.LookAt(player);
            targetloc = new Vector2(Random.Range(xmin,xmax), Random.Range(ymin,ymax));
            Vector3 newloc = new Vector3(targetloc.x, targetloc.y, transform.position.z);
            
           // transform.position = Vector2.MoveTowards(transform.position, targetloc, Time.deltaTime * speed);
            movetimer = orgtime1;
            transform.LookAt(player);
        }

        if (shoottimer<=0)
        {
            NormalFire();
        }

        if (bursttimer <= 0)
        {
            RapidFire();
            RapidFire();
            RapidFire();
            bursttimer = orgtime3;
        }
        movetimer -= Time.deltaTime;
        shoottimer -= Time.deltaTime;
        bursttimer -= Time.deltaTime;

        if (hp <= 35)
        {
            ds.Play();
        }

        if (hp<=0)
        {
            SceneManager.LoadScene("Level_2");
        }
    }
    private void FixedUpdate()
    {
        //transform.position.x = Mathf.Lerp(transform.position.x, targetloc.x, 10f);
        //transform.position.y = Mathf.Lerp(transform.position.y, targetloc.y, 10f);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetloc.x, speed), Mathf.Lerp(transform.position.y, targetloc.y, speed), transform.position.z);
        
        
    }


    public void NormalFire()
    {
        transform.LookAt(player);
        Instantiate(ammo, fire1.position, fire1.rotation);
        Instantiate(ammo, fire2.position, fire2.rotation);
        shoottimer = orgtime2;
        transform.LookAt(player);
    }

    public void RapidFire()
    {
        transform.LookAt(player);
       
            Instantiate(ammo, fire3.position, fire3.rotation);
        
        
        
    }





    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            hp--;
        }
    }



}
