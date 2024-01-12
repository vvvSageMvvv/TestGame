using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public float health, maxHealth;
    public GameOverScreen gos;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

    }

    public void GameOver()
    {
        gos.setup();

    }

    public void DamagePlayer(float dmg)
    {
        if (health - dmg <= 0)
        {
            health = 0;
            GameOver();
            OnPlayerDamaged?.Invoke();
        }
        else
        {
            health -= dmg;
            OnPlayerDamaged?.Invoke();
        }
    }
    public void HealPlayer(float amt)
    {
        if (health + amt >= maxHealth)
        {
            health += amt;
        }
        else
        {
            health = maxHealth;
        }
    }

}
