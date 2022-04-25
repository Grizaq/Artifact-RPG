using UnityEngine;

public class Sign : MonoBehaviour
{
    private GameObject triggerNPC; //Interaction started/possible
    private bool triggering; // activator of the inateraction

    public GameObject textBGs;
    public GameObject TextHelper;


    void Update()
    {
        if (triggering) // if player within range - text will be desplayed
        {
            textBGs.SetActive(true);
            TextHelper.SetActive(true);

        }
        else //while the player is not within range - the interaction is off
        {
            textBGs.SetActive(false);
            TextHelper.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) // interaction can happen only with player inside radius
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggerNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) // when leaving the collision radius, the parameters should be reset
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggerNPC = null;
        }
    }

}
