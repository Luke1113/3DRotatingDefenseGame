using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL11 : MonoBehaviour
{
    //근접
    Health healthScr;
    Player playerScr;
    ParticleSystem particle;
    [SerializeField] float speed, range, attackSpeed;
    [SerializeField] int damage;
    bool canAttack = true;
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
        playerScr = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        healthScr = GetComponent<Health>();
        healthScr.SetHealth(150);
    }
    private void Update()
    {
        if(Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.z, 2)) > range)
        {
            Vector3 moveVec = transform.position;
            transform.position -= moveVec.normalized * speed * Time.deltaTime;
        }
        else
        {
            if (canAttack)
            {
                canAttack = false;
                playerScr.Damage(damage);
                particle.Play();
                Invoke("StopParticle", 0.3f);
                Invoke("CanAttack", attackSpeed);
            }    
        }
    }
    void StopParticle()
    {
        particle.Stop();
    }
    void CanAttack()
    {
        canAttack = true;
    }
}
