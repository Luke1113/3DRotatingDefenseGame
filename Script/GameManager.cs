using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] unitL1, unitL2, unitL3, unitL4, unitL5;
    [SerializeField] GameObject[] treeObjs;
    [SerializeField] GameObject nextStageButton;
    [SerializeField] GameObject playerObj;
    Player playerScr;
    [SerializeField] int[,] stages =
    {
        { 3, 0, 0, 0, 0 }, { 4, 0, 0, 0, 0 }, { 5, 0, 0, 0, 0 }, { 7, 0, 0, 0, 0 }, { 7, 1, 0, 0, 0 },
        { 7, 3, 0, 0, 0 }, { 9, 4, 0, 0, 0 }, { 11, 5, 0, 0, 0 }, { 14, 7, 0, 0, 0 }, { 14, 7, 1, 0, 0 }
    };
    GameObject[][] units;
    int stage = 0, unitNum = 0, deathCount;
    
    private void Start()
    {
        playerScr = playerObj.GetComponent<Player>();
        for(int i = 0; i < treeObjs.Length; i++)
        {
            int random = Random.RandomRange(40, 50);
            for(int j = 0; j < random; j++)
            {
                float rand = 2 * Mathf.PI * Random.value;
                Vector3 pos = (15 + 30 * Random.value) * new Vector3(Mathf.Cos(rand), 0, Mathf.Sin(rand));
                Instantiate(treeObjs[i], pos, treeObjs[i].transform.rotation);
            }
        }
        
        units = new GameObject[][] {unitL1, unitL2, unitL3, unitL4, unitL5 };
        StartCoroutine("GenUnit", stage);
    }
    public void StartStage()
    {
        StartCoroutine("GenUnit", stage);
        nextStageButton.SetActive(false);
        playerScr.Heal(10 + stage * (playerScr.maxHealth - playerScr.health) / 10);
    }
    public void UnitDeath()
    {
        deathCount++;
        if(deathCount == unitNum)
        {
            nextStageButton.SetActive(true);
        }
    }
    IEnumerator GenUnit(int stage)
    {
        Debug.Log(stage);
        deathCount = 0;
        int u1, u2, u3, u4, u5;
        u1 = stages[stage, 0];
        u2 = stages[stage, 1];
        u3 = stages[stage, 2];
        u4 = stages[stage, 3];
        u5 = stages[stage, 4];
        unitNum = u1 + u2 + u3 + u4 + u5;
        while (true)
        {
            if(u1 == 0 && u2 == 0 && u3 == 0 && u4 == 0 && u5 == 0)
            {
                break;
            }
            float rand = 2 * Mathf.PI * Random.value;
            Vector3 pos = 30 * new Vector3(Mathf.Cos(rand), 0, Mathf.Sin(rand));
            float random = Random.Range(0, 5);
            if(u1 > 0)
            {
                u1--;
                int index = Random.Range(0, unitL1.Length);
                Instantiate(units[0][index], pos, Quaternion.identity);
            }
            else if (u2 > 0)
            {
                u2--;
                int index = Random.Range(0, unitL2.Length);
                Instantiate(units[1][index], pos, Quaternion.identity);
            }
            else if(u3 > 0)
            {
                u3--;
                int index = Random.Range(0, unitL3.Length);
                Instantiate(units[2][index], pos, Quaternion.identity);
            }
            else if(u4 > 0)
            {
                u4--;
                int index = Random.Range(0, unitL4.Length);
                Instantiate(units[3][index], pos, Quaternion.identity);
            }
            else if(u5 > 0)
            {
                u5--;
                int index = Random.Range(0, unitL5.Length);
                Instantiate(units[4][index], pos, Quaternion.identity);
            }
            yield return new WaitForSeconds(random);
        }
        this.stage++;
        Debug.Log(1);
        StopAllCoroutines();
    }
}
