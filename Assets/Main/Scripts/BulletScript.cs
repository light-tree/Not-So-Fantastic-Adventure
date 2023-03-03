using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    Rigidbody2D rb;
    [SerializeField]
    public float force;
    [SerializeField]
    Transform checkAttack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkAttack.position, 0.17f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.name.Contains("Enemy"))
            {
                Destroy(colliders[i].gameObject);
                Destroy(gameObject);
            }


            if (colliders[i].gameObject.name.Contains("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }


}
