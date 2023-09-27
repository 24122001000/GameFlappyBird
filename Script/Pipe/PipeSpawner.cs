using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1.2f);
        Vector3 temp = transform.position;
        temp.y = Random.Range(-1.25f, 2.5f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
