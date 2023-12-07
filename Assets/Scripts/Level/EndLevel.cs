using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public bool notLastLevel = true;
    [SerializeField] private ParticleSystem featherParticle;
    // Start is called before the first frame update
    void Start()
    {
        featherParticle.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!featherParticle.isPlaying)
        {
            featherParticle.Play();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && notLastLevel)
        {
            AudioManager.instance.Play("Win");
            GameManager.instance.LoadNextLevel();
            Destroy(this.gameObject);
        }
     
    }
}
