using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWorld : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    [Header("Logic")]
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Vector3 position = camera.WorldToScreenPoint(lookAt.position + offset);

        if(transform.position != position)
        {
            transform.position = position;
        }
    }
}
