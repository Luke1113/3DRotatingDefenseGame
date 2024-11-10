using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletObj, rangeObj, bulletPos, endButton;
    [SerializeField] Image healthBarImg;
    [SerializeField] float speed, maxPower;
    [SerializeField] float acceleration;
    float angle, power;
    bool isShooting, canFire, isGame;
    [SerializeField] public int health, maxHealth;
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            endButton.SetActive(true);
            isGame = false;
        }
        
        healthBarImg.fillAmount = (health + 0.0f) / maxHealth;
    }
    public void Heal(int heal)
    {
        if(health + heal < maxHealth)
        {
            health += heal;
        }
        else
        {
            health = maxHealth;
        }
        healthBarImg.fillAmount = (health + 0.0f) / maxHealth;
    }
    public void Reload()
    {
        rangeObj.SetActive(false);
        canFire = true;

    }
    private void Start()
    {
        Physics.gravity *= acceleration;
        angle = 0;
        power = 0;
        isShooting = false;
        canFire = true;
        isGame = true;
        maxHealth = 200;
        health = maxHealth;
    }

    //2*power*power/9.8
    private void Update()
    {
        if (isGame)
        {
            if (isShooting)
            {
                if (power < acceleration * maxPower)
                {
                    power += acceleration * 10 * Time.deltaTime;
                }
                float magnitude = 3 + (Mathf.Pow(power, 2) + Mathf.Sqrt((float)(Mathf.Pow(power, 4) - 17 * Physics.gravity.y * Mathf.Pow(power, 2)))) / (Physics.gravity.y * -2);

                rangeObj.transform.position = new Vector3(magnitude * Mathf.Sin(Mathf.Deg2Rad * angle), 0.01f, magnitude * Mathf.Cos(Mathf.Deg2Rad * angle));
            }
            else
            {
                angle += speed * Time.deltaTime;
                transform.eulerAngles = new Vector3(-90, angle + 90, 0);
            }
            if (canFire)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isShooting = true;
                    rangeObj.SetActive(true);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    canFire = false;
                    isShooting = false;
                    GameObject bullet = Instantiate(bulletObj, bulletPos.transform.position, Quaternion.identity);
                    Vector3 shootingVec = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 1, Mathf.Cos(Mathf.Deg2Rad * angle)).normalized;
                    bullet.GetComponent<Bullet>().SetVector(power * shootingVec);
                    power = 0;
                }
            }
        }
    }
}
