using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public GameObject cube; 
    private Renderer cubeRenderer;    
    private Color originalColor;      

    public Color flashColor = Color.red; 
    public float flashDuration = 0.2f;  

    void Start()
    {
        if (cube != null)
        {
            cubeRenderer = cube.GetComponent<Renderer>();

            if (cubeRenderer.material.HasProperty("_Color"))
            {
                originalColor = cubeRenderer.material.color;
            }
            else
            {
                Debug.LogWarning("Material on the cube does not have a '_Color' property. Flashing may not work.");
            }
        }
        else
        {
            Debug.LogError("Cube GameObject is not assigned in the inspector.");
        }
    }

    public void FlashColour()
    {
        StartCoroutine(FlashColor());
    }

    private System.Collections.IEnumerator FlashColor()
    {
        if (cubeRenderer.material.HasProperty("_Color"))
        {
            cubeRenderer.material.color = flashColor;
        }

        yield return new WaitForSeconds(flashDuration);

        if (cubeRenderer.material.HasProperty("_Color"))
        {
            cubeRenderer.material.color = originalColor;
        }
    }
}
