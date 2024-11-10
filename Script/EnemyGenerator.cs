using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void GenEnemy()
    {
        float rand = 2 * Mathf.PI * Random.value;
        Vector3 pos = new Vector3(Mathf.Cos(rand), 0, Mathf.Sin(rand));
        Instantiate(enemy, 20 * pos, Quaternion.identity);
        Invoke("GenEnemy", 2);
    }
    private void Start()
    {
        Invoke("GenEnemy", 2);
    }
}
