using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public GameObject Speed;
    public float animSpeed = 2.0f;
    public Animator animator;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup showerBackgroundImageCanvasGroup;


    bool m_IsPlayerAtBathroom;
    float m_Timer;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameEvent Trigger!!!!!!!");
        if (other.gameObject == player)
        {
            m_IsPlayerAtBathroom = true;
        }
    }

    void Update()
    {
        if (m_IsPlayerAtBathroom)
        {
            doEvent(showerBackgroundImageCanvasGroup);
        }
    }


    void doEvent(CanvasGroup imageCanvasGroup) 
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            imageCanvasGroup.alpha = 0;
            animator.speed = animSpeed;
            Speed.gameObject.SetActive(true);
        }
    }
}
