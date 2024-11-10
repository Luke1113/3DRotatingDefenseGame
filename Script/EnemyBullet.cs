using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Player playerScr;
    [SerializeField] float speed, range;
    [SerializeField] int damage;
    public void Initialize(int damage, int speed, int range)
    {
        this.damage = damage;
        this.speed = speed;
        this.range = range;
    }
    private void Start()
    {
        playerScr = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }
    private void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) > range)
        {
            transform.position -= transform.position.normalized * speed * Time.deltaTime;
        }
        else
        {
            playerScr.Damage(damage);
            Destroy(gameObject);
        }
    }
}
