using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public PlayerController pc;
    public Transform spawnPoint;
    public Animator anim;
    public float transitionTime = 1.5f;
    public float deathWaitTime;
    public GameObject pauseMenu;
    //public Camera cam;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player.transform.position = spawnPoint.position;
        pauseMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("escape open UI");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadNextLevel();
        }
    }

    public void GameOver()
    {
        CameraShake.instance.ShakeCamera();
        Invoke("ReloadCurrentLevel", deathWaitTime);
        //ReloadCurrentLevel();
    }

   
    
    public void LoadNextLevel()
    {
        print("level completed");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //pauseMenu.SetActive(false);
    }

    public void ReloadCurrentLevel()
    {
        print("reload level");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        //pauseMenu.SetActive(false);
    }

    //public void LoadMenu()
    //{
    //    print("reload level");
    //    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    //    pauseMenu.SetActive(false);
    //}

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");
        pauseMenu.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        //print("platform restore");
        //currentSprite.color = new Color(255, 255, 255);

    }
}

