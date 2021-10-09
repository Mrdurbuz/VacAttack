using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float delay = 1.0f;
    float delta = 0;

    public GameObject ghostParent;
    SpriteRenderer mySpriteRenderer;

    public float destroyTime = 0.1f;
    public Color tint;
    public Material myMaterial = null;


    // Update is called once per frame
    void Update()
    {
        if(delta > 0)
        {
            delta -= Time.deltaTime;
        }
        else
        {
            delta = delay;
            CreateGhost();
        }
    }

    void CreateGhost()
    {
        GameObject ghostObj = Instantiate(ghostPrefab, transform.position, transform.rotation);
        ghostObj.transform.localScale = ghostParent.transform.localScale;

        Destroy(ghostObj, destroyTime);

        mySpriteRenderer = ghostObj.GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = ghostParent.GetComponent<SpriteRenderer>().sprite;
        mySpriteRenderer.color = tint;

        if (myMaterial != null) mySpriteRenderer.material = myMaterial;
    }

}
