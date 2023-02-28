using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform checkAttack;
    [SerializeField]
    float checkAttackRadius = 0.35f;
    [SerializeField]
    float timeAttack = 1f;
    float time = 0;
    bool isAttack = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBeAttcked();
    }

    void CheckBeAttcked()
    {
        Collider2D[] collider2s = Physics2D.OverlapCircleAll(checkAttack.position, checkAttackRadius);
        if(collider2s.Length == 0)
        {
            time = 0;
        }
        for (int i = 0; i < collider2s.Length; i++)
        {
            if (collider2s[i].gameObject.name.Contains("Player"))
            {
                time += Time.deltaTime;
                if(time > timeAttack)
                {
                    isAttack = true;
                    time = 0;
                } 
                else
                {
                    isAttack = false;
                }
            }

        }

    }
}