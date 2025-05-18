using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyHighlighter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isPlayer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        isPlayer = CompareTag("Player");
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = 10;
        }
    }

    public void SetHighlight(bool highlight)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = highlight ? 
                (isPlayer ? new Color(0.2f, 0.4f, 1f) : new Color(1f, 0.3f, 0.3f)) : 
                originalColor;
            transform.localScale = highlight ? new Vector3(1.1f, 1.1f, 1f) : Vector3.one;
        }
    }
}