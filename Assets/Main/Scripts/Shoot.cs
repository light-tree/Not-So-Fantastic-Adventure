using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float speed;
    float time = 1f;
    [SerializeField]
    float timeShoot;
    float destinationX;
    float destinationY;

    Vector2 moving;
    // Start is called before the first frame update
    void Start()
    {
        //time = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            if(time >= timeShoot)
            {
                GameObject gameObject = Instantiate(bullet);
                gameObject.name = "Bullet";
                gameObject.transform.position = transform.position;
                gameObject.gameObject.SetActive(true);
                time = 0;
            } 
        } else
        {
            time = 0;
        }
    }

}
