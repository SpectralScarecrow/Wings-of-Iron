using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject body;
    public float hp = 60;
    [SerializeField]
    Planemove tracker;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
