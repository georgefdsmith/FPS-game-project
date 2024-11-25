using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;

        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable can ONLY use UnityEvents.", MessageType.Info);

            // Force `useEvents` to true
            interactable.useEvents = true;

            // Ensure InteractionEvent is present
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            // Default inspector for other Interactable types
            base.OnInspectorGUI();

            if (interactable.useEvents)
            {
                // Add InteractionEvent if missing
                if (interactable.GetComponent<InteractionEvent>() == null)
                {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                // Remove InteractionEvent if `useEvents` is false
                InteractionEvent interactionEvent = interactable.GetComponent<InteractionEvent>();
                if (interactionEvent != null)
                {
                    DestroyImmediate(interactionEvent);
                }
            }
        }
    }
}
