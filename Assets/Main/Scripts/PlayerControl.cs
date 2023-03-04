using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed = 25f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    UIDocument uIDocument;
    [SerializeField]
    int hp = 100;

    Rigidbody2D rigidbody;
    Vector2 moving;
    bool facingLeft = false;
    Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        moving = new Vector2(horizontal, vertical);

        //if(facingLeft && moving.x > 0)
        //{
        //    Debug.Log("> 0");
        //    Filp();
        //} else if(!facingLeft && moving.x < 0)
        //{
        //    Debug.Log("< 0");
        //    Filp();
        //}

        if(mousePos.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (mousePos.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        MoveObject(moving);
        //Filp();
    }

    void MoveObject(Vector2 direction)
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", direction != Vector2.zero ? speed : 0);
    }

    public void BeAttack(int damage)
    {
        GameController gameController = uIDocument.GetComponent<GameController>();
        hp -= damage;
        gameController.UpdateHealth(hp);
    }

    
}
