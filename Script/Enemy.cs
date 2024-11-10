using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.position -= transform.position.normalized * speed * Time.deltaTime;
    }
}
