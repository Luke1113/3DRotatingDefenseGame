using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL10 : MonoBehaviour
{
    //자폭
    Health healthScr;
    Player playerScr;
    [SerializeField] float speed, range;
    [SerializeField] int damage;
    private void Start()
    {
        playerScr = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        healthScr = GetComponent<Health>();
        healthScr.SetHealth(100);
    }
    private void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.z, 2)) > range)
        {
            Vector3 moveVec = transform.position;
            transform.position -= moveVec.normalized * speed * Time.deltaTime;
        }
        else
        {
            playerScr.Damage(damage);
            GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>().UnitDeath();
            Destroy(gameObject);
        }
    }
}
