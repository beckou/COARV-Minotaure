using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkull : MonoBehaviour
{
    float angle = 0f;
    float pas = 1f;
    bool inserted = false;
    // Update is called once per frame
    void Update()
    {
        inserted = gameObject.GetComponent<InsertEye>().getGoal();
        if (inserted)
        {
            if (angle != 30f)
            {
                float x = this.gameObject.transform.position.x;
                float y = this.gameObject.transform.position.y;
                float z = this.gameObject.transform.position.z;
                this.gameObject.transform.RotateAround(new Vector3(x, y, z), new Vector3(1, 0, 0), pas);
                new WaitForSeconds(0.1f);
                angle += pas;
            }
        }
    }
}
