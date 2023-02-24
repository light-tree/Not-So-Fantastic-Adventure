using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    [SerializeField]
    float speed = 7F;
    protected float maxDistance = 1F;
    bool facingLeft = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 distance = player.transform.position - transform.position;

        Vector3 target = playerPosition - distance.normalized * this.maxDistance; ;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);


        if(!facingLeft && playerPosition.x > transform.position.x)
        {
            Filp();
        } else if(facingLeft && playerPosition.x < transform.position.x)
        {
            Filp(); 
        }
    }

    void Filp()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
