using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class gameManager : MonoBehaviour {

    bool isFlare = false;

    bool win = false;

    public GameObject winPanel, lostPanel,checkText,GuideText;

    public GameObject eye, helicam;

    // Use this for initialization
    void Start () {
        isFlare = false;
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
        GuideText.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        eye.SetActive(true);
        helicam.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isFlare)
        {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var zombie in zombies)
            {
                Debug.Log("zombie see flare");
                zombie.SendMessage("SeeFlare");
            }           
        }

        if (win)
        {
            Debug.Log(win);
            eye.SetActive(false);
            helicam.SetActive(true);           
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!GuideText.activeInHierarchy)
            {
                GuideText.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                GuideText.SetActive(false);
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                QuitGame();
            }
        }
    }

    //create method for instantiating enemy after flare laid;
    void FlareLaid()
    {
        isFlare = true;
        BroadcastMessage("SpawnStart");
    }

    public void OnWin()
    {
        win = true;
        winPanel.SetActive(true);
        lostPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnLost()
    {
        winPanel.SetActive(false);
        lostPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
