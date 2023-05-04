using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject body;
    public float hp = 50;
    [SerializeField]
    Planemove tracker;
    public ParticleSystem ds;

    // Start is called before the first frame update
    void Start()
    {
        ds.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 25)
        {
            ds.Play();

        }


        if (hp<= 0)
        {
            tracker.turretcount--;
            Destroy(body);
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
