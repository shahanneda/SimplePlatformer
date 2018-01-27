using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int[] Levels;
    public GameObject levelsParent;
    public GameObject levelPrefab;
    public static int CurrentLevel;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        foreach (int i in Levels)
        {
            Level level = Instantiate(levelPrefab, levelsParent.transform).GetComponent<Level>();
            level.LevelNumber = i;
        }
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (DiamondCount.Diamonds > PlayerPrefs.GetInt("Level" + CurrentLevel))
            {
                PlayerPrefs.SetInt("Level" + CurrentLevel, DiamondCount.Diamonds);
            }
            
            DiamondCount.Diamonds = 0;
            SceneManager.LoadScene("LevelSelect" );
            CurrentLevel = 0;
        }
	}
    public static void  GoToNextLevel()
    {
        if (DiamondCount.Diamonds > PlayerPrefs.GetInt("Level" + CurrentLevel))
        {
             PlayerPrefs.SetInt("Level" + CurrentLevel, DiamondCount.Diamonds);
        }
       
        CurrentLevel++;
        DiamondCount.Diamonds = 0;
        SceneManager.LoadScene("Level" + CurrentLevel);
       
    }
    public static void Restart()
    {
        if (DiamondCount.Diamonds > PlayerPrefs.GetInt("Level" + CurrentLevel))
        {
            PlayerPrefs.SetInt("Level" + CurrentLevel, DiamondCount.Diamonds);
        }
        DiamondCount.Diamonds = 0;
        SceneManager.LoadScene("Level" + CurrentLevel);
    }
}
