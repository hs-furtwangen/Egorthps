using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    public Text timeText;

    void Start() {
        Instance = this;
    }

    public void SetTimeText(string newText) {
        timeText.text = newText;
    }
}
