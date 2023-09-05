using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    float m_timer;
    bool m_hasRecord = false;
    float m_fastestPlayTime;
    bool m_playTimer = true;

    void Awake()
    {
        if (PlayerPrefs.HasKey("FastestPlayTime"))
        {
            m_fastestPlayTime = PlayerPrefs.GetFloat("FastestPlayTime");
        } 
        else
        {
            m_fastestPlayTime = -1f;
        }
        
    }

    public void Stop(bool caught)
    {
        m_playTimer = false;
        if (!caught)
        {
            if(m_fastestPlayTime > m_timer)
            {
                Save();
            }        
        }
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("FastestPlayTime", m_timer);
    }


    void Update()
    {
        if(m_playTimer)
        {
            m_timer += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        Rect rect = new Rect(50, 10, w, h * 2 / 50);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2/ 50;
        style.normal.textColor = new Color(255f, 255f, 255f, 1f);

        string text = "Make Fisrt Record!";
        if(m_fastestPlayTime > 0) 
        {
            text = string.Format("Best Record: {0:N} s", m_fastestPlayTime);
        }
        text += string.Format("\n{0:N} s", m_timer);
        GUI.Label(rect, text, style);
    }
}
