using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    private EdgeCollider2D edgeCollder;
    private float timeSinceUpdate;
    private readonly float timeToUpdate = 1f;

    void Start()
    {
        edgeCollder = GetComponent<EdgeCollider2D>();
        SetEdges();
    }

    private void Update()
    {
        timeSinceUpdate += Time.deltaTime;
        if (timeSinceUpdate >= timeToUpdate)
        {
            timeSinceUpdate = 0;
            SetEdges();
        }
    }

    private void SetEdges()
    {
        List<Vector2> edges = new();
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edgeCollder.SetPoints(edges);
    }
}
