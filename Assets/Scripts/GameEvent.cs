using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup sleepBackgroundImageCanvasGroup;

    bool m_IsPlayerAtBad;
    float m_Timer;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameEvent Trigger!!!!!!!");
        if (other.gameObject == player)
        {
            m_IsPlayerAtBad = true;
        }
    }

    void Update()
    {
        if (m_IsPlayerAtBad)
        {
            EndLevel(sleepBackgroundImageCanvasGroup);
        }
    }


    void EndLevel(CanvasGroup imageCanvasGroup) 
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            imageCanvasGroup.alpha = 0;
        }
    }
}
