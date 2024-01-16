using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.3f);
    }
}
