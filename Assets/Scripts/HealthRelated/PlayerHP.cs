using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerHP : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Rigidbody2D r2d;
    float timer;
    bool invincible = false;
    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!invincible)
            {
                playerHealth.DamagePlayer(1);
                InvinciblePeriod();
                StartCoroutine(nameof(Flash));
                Vector2 dir;
                if (collision.transform.position.x>transform.position.x){
                    dir = new Vector2(collision.transform.position.x+5,collision.transform.position.y+5);
                } else {
                    dir = new Vector2(collision.transform.position.x-5,collision.transform.position.y+5);

                }
                StartCoroutine(KnockBack(0.02f,200,dir));
            } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            invincible = false;
        }
    }
    void InvinciblePeriod()
    {
        timer = 1;
        if (timer > 0)
        {
            invincible = true;
        }
    }

    IEnumerator KnockBack(float KnockBackDur, float knockbackPwr, Vector3 knockbackDir){
        float timer = 0;
        while (KnockBackDur > timer){
            timer+=Time.deltaTime;
            r2d.AddForce(new Vector3(knockbackDir.x*-100,knockbackDir.y * knockbackPwr,transform.position.z));
        }
        yield return 0;
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            sRend.material = mWhite;
            Invoke("ResetMaterial", 0.15f);
        }
    }

    void ResetMaterial()
    {
        sRend.material = mDefault;
    }
}
