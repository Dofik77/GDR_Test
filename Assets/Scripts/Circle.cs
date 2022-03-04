using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Circle : MonoBehaviour
{
    public event Action OnDestroy;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        var r = Random.Range(0f, 1f);
        var g = Random.Range(0f, 1f);
        var b = Random.Range(0f, 1f);
        
        _spriteRenderer.color = new Color(r,g,b);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Square cube))
        {
            Destroy(gameObject);
            OnDestroy?.Invoke();
        }
    }
}
