using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartManagement : MonoBehaviour
{
    public GameObject healthPrefab;
    public PlayerHealth playerHealth;
    List<Health> hearts = new();

    private void Start(){
        DrawHearts();
    }

    private void OnEnable(){
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable(){
        PlayerHealth.OnPlayerDamaged -= DrawHearts;
    }


    public void DrawHearts(){
        ClearHearts();
        float maxHealthRemainder = playerHealth.maxHealth%2;
        int heartsToMake =(int) ((playerHealth.maxHealth/2)+maxHealthRemainder);
        for (int i = 0;i<heartsToMake;i++){
            CreateEmptyHeart();
        }
        for (int i = 0; i <hearts.Count;i++){
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i*2),0,2);
            hearts[i].setHeartImage((Health.HeartStatus) heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart(){
        GameObject newHeart = Instantiate(healthPrefab);
        newHeart.transform.SetParent(transform);
        newHeart.transform.localScale = new Vector3(1,1,1);
        Health health = newHeart.GetComponent<Health>();
        health.setHeartImage(Health.HeartStatus.Empty);
        hearts.Add(health);
    }

    public void ClearHearts(){
        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }
        hearts = new List<Health>();
    }

}
