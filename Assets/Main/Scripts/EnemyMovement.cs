using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    [SerializeField]
    float speed = 7F;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;

        Vector3 target = playerPosition;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);

    }
}
