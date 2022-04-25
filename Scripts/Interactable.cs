using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform intercationTransform;
    bool isFocused = false;
    Transform player;
    

    bool hasInteracted; //interact with objects

    public virtual void Interact()
    {
        //virtual = to be overwritten based on the interactable obj
    }

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, intercationTransform.position);
            if (distance <= radius*3f)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform) //face and follow the interactable object
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected() //show the interactable area for items
    {
        if (intercationTransform == null)
            intercationTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(intercationTransform.position, radius);
    }


}
