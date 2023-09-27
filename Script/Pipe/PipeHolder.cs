using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance != null)
        {
            if(BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        PipeMovement();
    }

    void PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

}
