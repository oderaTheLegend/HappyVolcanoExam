using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static CubeManager instance;

    public List<CubeFunctions> taggedCubes;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SwitchTagToRandom()
    {
        for (int i = 0; i < taggedCubes.Count; i++)
        {
            taggedCubes[i].SwitchToRandomColour();
        }
    }
}