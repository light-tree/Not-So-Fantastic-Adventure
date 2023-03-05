using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeAttacked : MonoBehaviour
{

    [SerializeField]
    float MaxHealth;

    float CurrentHealth;
    GameObject HealthBar;
    Animator animator;

    bool IsAttacked;
    float timeHit = 0.1f;
    float time;
    float timeEndHit;

    bool IsDead;
    float timeDead = 0.5f;
    float time2;
    float timeEndDead;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar = transform.Find("HealthBarCanvas").gameObject.transform.Find("HealthBar").gameObject;
        animator = GetComponent<Animator>();
        animator.enabled = true;
        IsAttacked = false;
        IsDead = false;
        time = 0;
        time2 = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        time += Time.deltaTime;
        if (IsAttacked && time >= timeEndHit)
        {
            IsAttacked=false;
            animator.Play("Run");
        }

        time2 += Time.deltaTime;
        if (IsDead)
        {
            if (time2 < timeEndDead)
            {
                Vector2 vector2 = gameObject.transform.position;
                gameObject.transform.position = new Vector2(vector2.x, vector2.y - 0.015f);
            }
            else
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }

        }
    }

    public void BeAttacked(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            animator.Play("Dead");
            IsDead = true;
            Destroy(HealthBar);
            Destroy(gameObject.GetComponent<EnemyMovement>());
            Destroy(gameObject.GetComponent<EnemyAttack>());
            IsDead = true;
            timeEndDead = time2 + timeDead;
            Vector2 vector2 = gameObject.transform.position;
            gameObject.transform.position = new Vector2(vector2.x, vector2.y + 1f);
        }
        else
        {
            animator.Play("Hit");
            Vector2 vector2 = HealthBar.GetComponent<RectTransform>().sizeDelta;
            HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentHealth / MaxHealth, vector2.y);
            Vector2 vector21 = HealthBar.GetComponent<RectTransform>().position;
            HealthBar.GetComponent<RectTransform>().position = new Vector2(vector21.x - (damage / (MaxHealth * 2)), vector21.y);
            IsAttacked=true;
            timeEndHit = time + timeHit;
        }
    }
}
