using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bistecs : MonoBehaviour
 
{
    float force, force2;
    public float pereza;
    public GameObject[] filetillos;

    // Start is called before the first frame update
    void Start()
    {
        filetillos = GameObject.FindGameObjectsWithTag("filetillos");

        foreach (GameObject child in filetillos)
        {
            force = Random.Range(-pereza, pereza);
            force2 = Random.Range(-pereza*0.1f, pereza*0.1f);
            child.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.position.x * force2, this.transform.position.y * force * Time.fixedDeltaTime));
        }
    }
}
