using UnityEngine;
using System.Collections;

public class LavaMovement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(LavaFlow());
    }

    private IEnumerator LavaFlow()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        
    }
}
