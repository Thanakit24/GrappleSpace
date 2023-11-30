using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player touched, call dead");
            collision.gameObject.GetComponent<PlayerController>().Dead();
        }

    }
}


