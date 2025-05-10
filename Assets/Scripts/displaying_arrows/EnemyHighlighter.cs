using UnityEngine;

public class EnemyHighlighter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void SetHighlight(bool highlight)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = highlight ? Color.red : originalColor;
        }
    }
}