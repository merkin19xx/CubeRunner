using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstance : MonoBehaviour
{
    public static TestInstance Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
