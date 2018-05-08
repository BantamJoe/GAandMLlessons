using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {

    public float timeToDie = 0;
    //gene for colour
    public float r;
    public float g;
    public float b;
    

    bool dead = false;

    SpriteRenderer sRenderer;
    Collider2D sCollider;

    // Use this for initialization
    void Start () {
        sRenderer = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<Collider2D>();
        sRenderer.color = new Color(r, g, b);
	}

	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elapsed;
        sRenderer.enabled = false;
        sCollider.enabled = false;

        Debug.Log("Dead At: " + timeToDie);
    }
}
