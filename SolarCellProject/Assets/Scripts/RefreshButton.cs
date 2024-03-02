using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public APIAccessor apiAccessor;

    private void OnMouseDown()
    {

        transform.localPosition += new Vector3(-0.003f, 0, 0);
        apiAccessor.onRefresh();
    }

    private void OnMouseUp()
    {
        transform.localPosition += new Vector3(0.003f, 0, 0);
    }
}
