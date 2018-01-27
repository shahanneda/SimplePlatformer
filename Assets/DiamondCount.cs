using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCount : MonoBehaviour {
    public static int Diamonds =0;

    private void Update()
    {
        GetComponent<Text>().text = Diamonds.ToString();
    }
}
