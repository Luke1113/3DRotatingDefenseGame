using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL20 : MonoBehaviour
{
    //원거리
    Health healthScr;
    [SerializeField] float speed, range, attackSpeed;
    [SerializeField] int damage;
    [SerializeField] GameObject bulletObj;
    bool canAttack = true;
    private void Start()
    {
        healthScr = GetComponent<Health>();
        healthScr.SetHealth(150);
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
            if (canAttack)
            {
                canAttack = false;
                GameObject bullet = Instantiate(bulletObj, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                bullet.GetComponent<EnemyBullet>().Initialize(damage, 10, 1);
                Invoke("CanAttack", attackSpeed);
            }
        }
    }
    void CanAttack()
    {
        canAttack = true;
    }
}
