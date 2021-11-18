using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Vector2 destination;

    private void Update()
    {
        Movement();
        SpriteFipe();
    }
    void Movement()
    {
        transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
    }
    void SpriteFipe()
    {

    }
}
