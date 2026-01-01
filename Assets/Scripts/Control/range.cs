using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    public void NormalizeEuler(ref Vector3 rEuler)
    {
        if (rEuler.x < -180f)
        {
            rEuler.x += 360f;
        }
        else if (rEuler.x > 180f)
        {
            rEuler.x -= 360f;
        }

        if (rEuler.y < -180f)
        {
            rEuler.y += 360f;
        }
        else if (rEuler.y > 180f)
        {
            rEuler.y -= 360f;
        }
    }
}
