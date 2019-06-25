using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject player;
    public TextMeshProUGUI score;
    public bool playerDead;
    public Animator finalScorePanelAnimator;
    public TextMeshProUGUI finalScore;
    public bool once;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead & !once)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        finalScorePanelAnimator.SetBool("gameOver", true);
        once = true;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
