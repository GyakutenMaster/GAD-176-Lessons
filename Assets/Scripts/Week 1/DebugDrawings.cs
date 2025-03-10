using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawings : MonoBehaviour
{
    public Transform target;

    public float radius;
    public float startAngle = 45f;
    public float endAngle = 125f;
    public int resolution = 100; // how many lines to draw for my arc.

    // Start is called before the first frame update
    void Start()
    {
        //DebugLine();
    }

    // Update is called once per frame
    void Update()
    {
        DebugRay();
    }

    void DebugLine()
    {
        if(!target)
        {
            return;
        }

        Debug.DrawLine(transform.position, target.position, Color.red,5);
    }

    void DebugRay()
    {
        if (!target)
        {
            return;
        }

        //Vector3 direction = transform.position - target.position;

        Debug.DrawRay(target.position, transform.forward, Color.blue);
        Debug.DrawRay(target.position, transform.right, Color.red);
        Debug.DrawRay(target.position, transform.up, Color.yellow);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1)); // Useful for spawnpoints

        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireCube(transform.position, new Vector3(2, 2, 2));

        DrawArc();
    }

    private void OnDrawGizmosSelected()
    {
        // Draws objects like the above OnDrawGizmos() , but only appears when they are selected in Hierarchy. Very handy when I only want to select certain objects, rather than having drawn all the time.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(2, 2, 2));
    }

    void DrawArc()
    {
        Gizmos.color = Color.red;

        float angleIncrement = (endAngle - startAngle) / resolution; // how far apart each of my lines should be.
        float currentAngle = startAngle; // where to start drawing from.

        // draw the rest of the arc lines
        for (int i = 0; i <= resolution; i++)
        {
            // grab the x and y coordinates for my lines
            float x = radius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float y = radius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

            // draw the current line
            Vector3 point = transform.position + new Vector3(x, y, 0);
            Gizmos.DrawLine(point, transform.position);

            // increase the current angle by the increment
            currentAngle += angleIncrement;
        }
    }
}
