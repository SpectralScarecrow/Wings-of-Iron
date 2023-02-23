using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planemove : MonoBehaviour
{
    public int turretcount = 3;
    public float hp = 30;
    public GameObject tospawn;
    public Transform gun1;
    public Transform gun2;
    public float forspeed;
    public float strafespeed;
    public float hoverspeed;
    public float activeforspeed;
    public float activestrafespeed;
    public float activehoverspeed;
    public float strafeaccel;
    public float hoveraccel;
    public float lookrate = 90f;
    public Vector2 lookinput, screencenter, mousedis;
    public float rollinput;
    public float rollspeed=90f, rollaccel= 3.5f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        screencenter.x = Screen.width * .5f;
        screencenter.y = Screen.height * .5f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        lookinput.x = Input.mousePosition.x;
        lookinput.y = Input.mousePosition.y;

        mousedis.x = (lookinput.x - screencenter.x) / screencenter.y;
        mousedis.y = (lookinput.y - screencenter.y) / screencenter.y;
        mousedis = Vector2.ClampMagnitude(mousedis, 1f);

        rollinput = Mathf.Lerp(rollinput, Input.GetAxisRaw("Roll"), rollaccel * Time.deltaTime);



        transform.Rotate(-mousedis.y * lookrate * Time.deltaTime, mousedis.x * lookrate * Time.deltaTime, rollinput * rollspeed * Time.deltaTime, Space.Self);


        transform.position += transform.forward * activeforspeed * Time.deltaTime;
        activestrafespeed = Mathf.Lerp(activestrafespeed, Input.GetAxisRaw("Horizontal") * strafespeed, strafeaccel * Time.deltaTime);//strafespeed * Input.GetAxisRaw("Horizontal");
        activehoverspeed = Mathf.Lerp(activehoverspeed, Input.GetAxisRaw("Hover") * hoverspeed, hoveraccel * Time.deltaTime);//hoverspeed * Input.GetAxisRaw("Hover");


        //nonforward movement
        transform.position += transform.right * activestrafespeed * Time.deltaTime;
        transform.position += transform.up * activehoverspeed * Time.deltaTime;
        //
        // transform.Rotate(Input.GetAxis("Vertical")/4, 0.0f, -Input.GetAxis("Horizontal")/4);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                gun1.LookAt(hit.point);
                gun2.LookAt(hit.point);
                Instantiate(tospawn, gun1.position, gun1.rotation);
                Instantiate(tospawn, gun2.position, gun2.rotation);
            }
        }





        if (hp <= 0)
        {

            SceneManager.LoadScene("Game_Over");
        }

        if (turretcount <= 0)
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



}
