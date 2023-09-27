using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Vector3 tempScale;
    [SerializeField]
    float worldHeight;
    [SerializeField]
    float worldWidth;
    [SerializeField]
    float height;
    [SerializeField]
    float width;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        tempScale = transform.localScale;
        worldHeight = Camera.main.orthographicSize*2f;
        worldWidth = worldHeight * Screen.width / Screen.height;
        height = sr.bounds.size.y;
        width = sr.bounds.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
    }

}
