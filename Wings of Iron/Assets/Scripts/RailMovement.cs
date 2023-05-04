using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RailMovement : MonoBehaviour
{
    public CopterBoss cb;
    public float activestrafespeed;

    public float strafespeed;
    public float strafeaccel;
    public GameObject tospawn;
    public float hoverspeed;
    public float hoveraccel;
    public float rof;
    public float nf;

    public float activehoverspeed;

    public Vector2 lookinput, screencenter, mousedis;
    public Transform gun1, gun2;
    public float hp;
    public ParticleSystem ds;
    // Start is called before the first frame update
    void Start()
    {
        screencenter.x = Screen.width * .5f;
        screencenter.y = Screen.height * .5f;
        Cursor.lockState = CursorLockMode.Confined;
        ds.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        activestrafespeed = Mathf.Lerp(activestrafespeed, Input.GetAxisRaw("Horizontal") * strafespeed, strafeaccel * Time.deltaTime);
        activehoverspeed = Mathf.Lerp(activehoverspeed, Input.GetAxisRaw("Vertical") * hoverspeed, hoveraccel * Time.deltaTime);//hoverspeed * Input.GetAxisRaw("Hover");
        
        transform.position += transform.right * activestrafespeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * activehoverspeed * Time.deltaTime;
        }
        

        if ( Time.time > nf && Input.GetMouseButtonDown(0))
        {
            nf = Time.time + rof;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                gun1.LookAt(hit.point);
                gun2.LookAt(hit.point);
                Instantiate(tospawn, gun1.position, gun1.rotation);
                Instantiate(tospawn, gun2.position, gun2.rotation);
            }
        }

        

        if (hp <= 10)
        {
            ds.Play();
        }


        if (hp <= 0)
        {
            
                SceneManager.LoadScene("Title");
         }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bossbullet"))
        {
            hp--;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cloud"))
        {
            hp -= .1f;
        }
    }


}
