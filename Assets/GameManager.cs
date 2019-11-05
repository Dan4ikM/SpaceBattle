using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    
    [SerializeField]
    private GameObject menu;
    
    public static GameManager instance = null;

    private bool isPause;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        spawner.StartSpawn();
    }

    public void Pause()
    {
        isPause = !isPause;
        Time.timeScale = (Time.timeScale == 0)? 1 : 0;
    }

    public void EndGame()
    {
        spawner.StopSpawn();
        menu.SetActive(true);

        if (isPause)
            Pause();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
