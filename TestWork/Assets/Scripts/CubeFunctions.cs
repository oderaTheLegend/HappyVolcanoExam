using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFunctions : MonoBehaviour
{
    public Color colorIni = Color.white;
    public Color colorFin = Color.red;
    public float duration = 3f;
    Color lerpedColor = Color.white;
    public Renderer _renderer;

    private float t = 0;
    private bool transitioning;

    int numberOfClicks;

    private void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        _renderer.material.color = lerpedColor;

        if(transitioning)
        {
            t += Time.deltaTime / duration;
        }
    }

    IEnumerator SwitchComplete()
    {
        yield return new WaitForSeconds(duration);
        transitioning = false;
    }

    private void OnMouseDown()
    {
        if(transitioning == false)
        {
            numberOfClicks++;
            t = 0;
            transitioning = true;

            StopAllCoroutines();
            StartCoroutine(SwitchComplete());

            if (numberOfClicks == 1)
            {
                CubeManager.instance.taggedCubes.Add(this);
                this.gameObject.tag = "Tagged";

                colorIni = Color.white;
                colorFin = Color.red;
            }
            else
            {
                CubeManager.instance.taggedCubes.Remove(this);
                this.gameObject.tag = "Untagged";

                numberOfClicks = 0;
                colorIni = Color.red;
                colorFin = Color.white;
            }
        }     
    }

    public void SwitchToRandomColour()
    {
        transitioning = true;
        t = 0;
        StopAllCoroutines();
        StartCoroutine(SwitchComplete());
        colorIni = _renderer.material.GetColor("_Color");
        colorFin = Random.ColorHSV();
    }
}