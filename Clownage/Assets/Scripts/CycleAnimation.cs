using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleAnimation : MonoBehaviour
{
    public Sprite[] imagesToCycle;
    public double fps;

    private SpriteRenderer spriteRenderer;
    private bool forwardAnimation = true;
    private int frameIdx = 0;
    private double lastFrameTime = 0;
    private double animFrameTime = 1;

    void incrementAnimFrame(float t)
    {
        if (imagesToCycle.Length <= 0)
            return;
        if (forwardAnimation)
        {
            if (frameIdx >= imagesToCycle.Length - 1)
            {
                frameIdx = imagesToCycle.Length - 1;
                forwardAnimation = false;
                --frameIdx;
            }
            else
                ++frameIdx;
        }
        else
        {
            if (frameIdx == 0)
            {
                forwardAnimation = true;
                ++frameIdx;
            }
            else
                --frameIdx;
        }
        lastFrameTime = t;
        Debug.Log(frameIdx);
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animFrameTime = 1 / fps;
    }

    // Update is called once per frame
    void Update()
    {
        /*float t = Time.time;
        float dt = t - lastFrameTime;
        for (int i = 1; i < dt / animFrameTime; ++i)
            incrementAnimFrame(t);*/
        int oldIdx = frameIdx;
        if (imagesToCycle.Length > 0)
            frameIdx = ((int)(Time.time * imagesToCycle.Length)) % imagesToCycle.Length;
        if (oldIdx != frameIdx)
            //Debug.Log(frameIdx);
        spriteRenderer.sprite = imagesToCycle[frameIdx];
    }
}
