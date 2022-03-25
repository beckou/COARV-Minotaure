using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkull : MonoBehaviour
{
    float angle = 0f;
    float pas = 1f;
    bool inserted = false;
    private float delay = 0.025f;
    private float time_update = 0f;

    // Update is called once per frame
    void Update()
    {
        inserted = gameObject.GetComponent<InsertEye>().getGoal();
        if (inserted)
        {
            float time = Time.time;
            if (angle<=30)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                if (time > time_update)
                {
                    gameObject.transform.RotateAround(new Vector3(x, y, z), new Vector3(1, 0, 0), pas);
                    angle += pas;
                    time_update = Time.time + delay;
                }
            }
        }
    }
}
