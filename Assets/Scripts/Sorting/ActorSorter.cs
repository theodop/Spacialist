using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSorter : MonoBehaviour {

    private const int MODULUS = 1000;

    SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () {
		if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = (int)(-transform.position.y * 100)%MODULUS;
        }
	}
}
