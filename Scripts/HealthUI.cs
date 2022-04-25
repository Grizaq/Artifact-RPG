using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPref;
    public Transform target;
    float healthBarDisplayTime = 5;
    float healthBarLastDisplay; //timer for when the health bar was efficient last

    Transform cam;
    Transform ui;
    Image healthSlider;

    void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>()) //creating a health bar for each active character
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPref, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break;
            }
        }
        GetComponent<CharacterStats>().OnHealthChange += OnHealthChange;
    }

    void OnHealthChange(int maxHP, int currentHP)
    {
        if(ui != null) //updating the fill of the health bar
        { 
            ui.gameObject.SetActive(true);
            healthBarLastDisplay = Time.time;
            float healthPercent = (float)currentHP / maxHP;
            healthSlider.fillAmount = healthPercent;
            if (currentHP <= 0)
            {
                Destroy(ui.gameObject); //alternatively adding animation
            }
        }
    }

    void LateUpdate()
    {
        if (ui != null) // inactive health bar dissapearing
        {

            ui.position = target.position;
            ui.forward = -cam.forward;

            if (Time.time - healthBarLastDisplay > healthBarDisplayTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
    }
}
