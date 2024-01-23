using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIsland : MonoBehaviour
{
    private Vector3 startPos;
    public bool randomVariables;
    [SerializeField, Range(0, 3)] private float frequency;
    [SerializeField, Range(0, 3)] private float magnitude;
    [SerializeField, Range(0, 3)] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        if (randomVariables)
        {
            frequency = Random.Range(0.9f, 1.5f);
            magnitude = Random.Range(0.2f, 0.4f);
            offset = Random.value * 3;

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
