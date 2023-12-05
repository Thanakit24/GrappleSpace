using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portalDestination;
    public bool firstPortal;
    public Transform portalA;
    public Transform portalB;
    public float distance = 0.4f;
    public GameObject poop;
    public bool isTeleport = false;
    public float resetTime;
    // Start is called before the first frame update
    void Start()
    {
        if (!firstPortal)
        {
            portalDestination.position = portalA.transform.position;
        }
        else
        {
            portalDestination.position = portalB.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // play animation or particles
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Poop") && !isTeleport)
        {
          
            if (Vector2.Distance(transform.position, collision.transform.position) > distance)
            {
                //instantiate poop prefab on the next portal to prevent trail renderer from transitioning
                isTeleport = true;
                Destroy(collision.gameObject);
                Instantiate(poop, portalDestination.position, Quaternion.identity);
                StartCoroutine(ResetPortal(resetTime));
            }
        }
    }

    IEnumerator ResetPortal(float resetTime)
    {
       
        yield return new WaitForSeconds(resetTime);
        print("portal ready"); 
        isTeleport = false;
        //print("platform restore");
        //currentSprite.color = new Color(255, 255, 255);

    }

}
