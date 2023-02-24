using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed = 25f;
    [SerializeField]
    Animator animator;

    Rigidbody2D rigidbody;
    Vector2 moving;
    bool facingLeft = true;
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

        
        moving = new Vector2(horizontal, vertical);

        if(facingLeft && moving.x > 0)
        {
            Filp();
        } else if(!facingLeft && moving.x < 0)
        {
            Filp();
        }
    }

    private void FixedUpdate()
    {
        MoveObject(moving);
    }

    void MoveObject(Vector2 direction)
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", direction != Vector2.zero ? speed : 0);
    }

    void Filp()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
