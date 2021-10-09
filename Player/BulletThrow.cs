using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletThrow : MonoBehaviour
{
    GhostEffect ghost;
    public float speed;

    Transform mira;

    void Start()
    {
        ghost = GetComponent<GhostEffect>();
        ghost.enabled = false;
    }

    void Update()
    {
        ghost.enabled = true;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(this.gameObject, 6);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemie")
        {
            if (col.GetComponent<Cow>())
            {
                col.GetComponent<Cow>().DestroyEffectInShoot();
            }
            if (col.GetComponent<FlyingCow>())
            {
                col.GetComponent<FlyingCow>().DestroyEffectInShoot();
            }
            Destroy(this.gameObject);
        }
    }
}
