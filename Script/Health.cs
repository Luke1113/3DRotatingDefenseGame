using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image healthBarImg;

    int health, maxHealth;

    public void SetHealth(int health)
    {
        maxHealth = health;
        this.health = health;
    }
    public void Damage(int damage)
    {
        health -= damage;
        healthBarImg.fillAmount = (health + 0.0f) / maxHealth;
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>().UnitDeath();
            Destroy(gameObject);
        }
    }
}
