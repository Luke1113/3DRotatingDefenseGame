using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidbody;
    ParticleSystem particle;
    bool hit = false;
    public float bombRange;
    private void Start()
    {
        bombRange = 3;
    }
    public void SetVector(Vector3 shootingVec)
    {
        rigidbody = GetComponent<Rigidbody>();
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
        rigidbody.velocity = shootingVec;
    }
    private void Update()
    {
        
        if (!hit && (Physics.Raycast(transform.position, Vector3.down, 1, 1 << 6) || Physics.Raycast(transform.position, Vector3.up, Mathf.Infinity, 1 << 6)))
        {
            hit = true;
            GameObject.FindGameObjectWithTag("player").GetComponent<Player>().Reload();
            particle.Play();
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(transform.position, bombRange, Vector3.up, 0, 1 << 7);
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].collider.GetComponent<Health>().Damage(100);
            }
            Destroy(rigidbody);
            Destroy(gameObject, 1);
        }
    }
}
