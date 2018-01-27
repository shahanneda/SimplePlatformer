using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level : MonoBehaviour {
    public int LevelNumber;
    public Text score;

    void Start()
    {
       
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Load);
        btn.GetComponent<Text>().text = LevelNumber.ToString();
        int HighestLevelDiamonds = PlayerPrefs.GetInt("Level" + LevelNumber);
        score.text = HighestLevelDiamonds.ToString();
        
    }

    void Load()
    {
        LevelManager.CurrentLevel = LevelNumber;
        SceneManager.LoadScene("Level" + LevelNumber);
    }
}
