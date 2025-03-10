using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometry : MonoBehaviour
{
    public float amplitude = 1;
    public float frequency = 1;
    public float rotationSpeed = 45;

    public int resolution = 100; // the number of points to show.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveWithSin();
        //MoveWithCosine();
        //RotateObjectWithTan();
    }

    void RotateObjectWithTan()
    {
        // rotate object using tan.
        float rotatingAngle = Mathf.Tan(Time.time * rotationSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, rotatingAngle);
        // useful for modelling slopes and inclinations, such as a hill that is too steep. Also can use it for steering such as AI parking or character to follow a path, or projectiles like arcs in Angry Birds.
    }

    void MoveWithCosine()
    {
        // this will also move my cube, but it's going to move it left and right in a cosine wave pattern.
        float xPosition = amplitude * Mathf.Cos(Time.time * frequency);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        // can use it for having sway in your character to emulate balancing, moving objects.
        // out of sync cosine wave is useful for different bullet pattern that is out of sync so players can dodge in bullet hells.
    }

    void MoveWithSin()
    {
        // oscilating vertical motion
        // taking the current position adding the amplitude to it, and multiplying it by the current time and the frequency it should occur
        float yPosition = (transform.position.y + amplitude) * Mathf.Sin(Time.time * frequency);

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        // useful for character head bobbing, floating objects, interesting pattern for when shooting objects, pendulums such as giant axes.
    }

    private void OnDrawGizmos()
    {
        DrawSineWave();
        DrawCosWave();
        DrawTangentGraph();
    }

    void DrawSineWave()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i <= resolution; i++)
        {
            float x = i / (float)resolution * 4 * Mathf.PI; // just using the number 4 to increase
            float y = amplitude * Mathf.Sin(frequency * x);

            Vector3 point = new Vector3(x, y, 0);

            Gizmos.DrawSphere(point, 0.05f);
        }
    }

    void DrawCosWave()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i <= resolution; i++)
        {
            float x = i / (float)resolution * 4 * Mathf.PI; // just using the number 4 to increase
            float y = amplitude * Mathf.Cos(frequency * x);

            Vector3 point = new Vector3(x, y, 1f);

            Gizmos.DrawSphere(point, 0.05f);
        }
    }

    void DrawTangentGraph()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i <= resolution; i++)
        {
            float x = i / (float)resolution * 4 * Mathf.PI; // just using the number 4 to increase
            float y = amplitude * Mathf.Tan(frequency * x);

            // clamp the number so it can't go past -10 or above 10.
            y = Mathf.Clamp(y, -10f, 10f);

            Vector3 point = new Vector3(x, y, 2f);

            Gizmos.DrawSphere(point, 0.05f);
        }
    }
}
