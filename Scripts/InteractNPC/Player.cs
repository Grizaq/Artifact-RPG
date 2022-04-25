using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private GameObject triggerNPC; //"selected" npc
    private bool triggering; // activator of the inateraction

    Inventory inventory;


    public GameObject textNPC;
    public GameObject textBG;
    public GameObject TextCommanderSword;
    public GameObject TextCommanderNoSword;
    [SerializeField] GameObject GameManager;

    void NextScene() //changing the scene/ending game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    int i = 0;

    void Update()
    {

        if (triggering) //in effective collider range
        {
            if (i == 0)
            {
                textNPC.SetActive(true);
            }
            textBG.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F)) //changing scene after interaction
            {
                i = 1;
                textNPC.SetActive(false);
                inventory = GameManager.GetComponent<Inventory>();
                var nrIT = inventory.items.Count;

                if (nrIT >= 1) // if the inventory is not empty to avoid no inventory script case
                {
                    var name = inventory.items[0].name;

                    if (name == "Sword") // for an actual game with more items - requiring a loop to check more slots
                    {
                        TextCommanderSword.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            Invoke("NextScene", 4); //delay the scene change
                        }

                        
                    }
                    
                }
                else if (name != "Sword") //alternative response for condition not met
                {
                    i = 1;
                    TextCommanderNoSword.SetActive(true); 
                }
            }
        }
        else //keeping the text hidden unless required
        {
            textNPC.SetActive(false);
            textBG.SetActive(false);
            TextCommanderSword.SetActive(false);
            TextCommanderNoSword.SetActive(false);
            i = 0;
        }
    }
    private void OnTriggerEnter(Collider other) // interaction can happen only with objects tagged as NPC within its radius
    {
        if (other.tag == "NPC")
        {
            triggering = true;
            triggerNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggerNPC = null;
        }
    }
}
