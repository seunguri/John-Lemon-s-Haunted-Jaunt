using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    float m_timer;
    float m_playTime;

    void Awake()
    {
        if (PlayerPrefs.HasKey("PlayTime"))
        {

        }
        
    }


    void Update()
    {
        m_timer += Time.deltaTime;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2/ 50;
        style.normal.textColor = new Color(255f, 255f, 255f, 1f);

        Rect totalRect = new Rect(50, 10, w, h * 2 / 50);
        string text = string.Format("Total PlayTime: {0:N} s\n {0:N} s", m_timer , m_timer);
        GUI.Label(totalRect, text, style);

        // Rect rect = new Rect(50, 60, w, h * 2 / 50);
        // text = string.Format("", m_timer);
        // GUI.Label(rect, text, style);
    }
}
