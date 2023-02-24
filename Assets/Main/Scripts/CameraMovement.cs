using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    void Update()
    {
        //transform.position = player.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void LateUpdate()
    {
        Vector3 vector3 = transform.position;
        vector3.x = player.gameObject.transform.position.x;
        transform.position = player.gameObject.transform.position;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
