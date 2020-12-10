using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideManager : MonoBehaviour
{
    public static SideManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + nameof(SideManager) + " in the scene");
            return;
        }
        instance = this;
    }

}
