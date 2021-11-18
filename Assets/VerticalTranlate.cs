using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTranlate : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;
    private void Update()
    {
        transform.Translate(Vector3.left* Time.deltaTime * speed);
    }
}
