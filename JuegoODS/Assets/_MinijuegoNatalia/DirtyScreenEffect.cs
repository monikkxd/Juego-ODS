using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DirtyScreenEffect : MonoBehaviour
{
    public Material dirtyScreenMaterial;
    public float duration = 5.0f;

    private float timeElapsed = 0f;
    private bool effectComplete = false;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (dirtyScreenMaterial != null)
        {
            if (!effectComplete)
            {
                timeElapsed += Time.deltaTime;
                float t = Mathf.Clamp01(timeElapsed / duration);
                dirtyScreenMaterial.SetFloat("_TimeParam", t);

                if (t >= 1f)
                {
                    effectComplete = true;
                }
            }

            Graphics.Blit(src, dest, dirtyScreenMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}

