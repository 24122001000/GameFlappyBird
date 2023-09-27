using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;

    private Rigidbody2D birdBody;

    private GameObject spawner;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float bounceForce;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip wingClip, swooshClip, pointClip, hitClip, dieClip;

    private bool isAlive;
    private bool didFlap;

    public float flag = 0;
    public int score = 0;

    private void Awake()
    {
        isAlive = true;
        birdBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bounceForce = 4f;
        audioSource = GetComponent<AudioSource>();
        MakeInstance();
        spawner = GameObject.Find("PipeSpawner");
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        BirdMovement();
    }

    private void BirdMovement()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                birdBody.velocity = Vector2.up * bounceForce;
                audioSource.PlayOneShot(wingClip);
            }
        }
       

        if (birdBody.velocity.y > 0)
        {
            //Tìm góc quay cho birdBody
            float angel = 0f;
            angel = Mathf.Lerp(0, 90, birdBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (birdBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angel = 0f;
            angel = Mathf.Lerp(0, -90, -birdBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void FlapBtn()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PipeHolder")
        {
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.SetScore(score);
            }
            audioSource.PlayOneShot(pointClip);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            flag = 1;
            anim.SetTrigger("Died");
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(hitClip);
            }
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.ShowPanel(score);
            }
        }
    }
}
