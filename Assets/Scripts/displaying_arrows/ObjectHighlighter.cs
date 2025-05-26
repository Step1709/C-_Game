using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HighlightOnMouse2D : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.white;
    private Material originalMaterial;
    private Renderer objectRenderer;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer == null) return;
        var mat = new Material(Shader.Find("Sprites/Default"));
        mat.color = highlightColor;
        objectRenderer.material = mat;
    }

    void OnMouseExit()
    {
        if (objectRenderer == null) return;
        objectRenderer.material = originalMaterial;
    }
}