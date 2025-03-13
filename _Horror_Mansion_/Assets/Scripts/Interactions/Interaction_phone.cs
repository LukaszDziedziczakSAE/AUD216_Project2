using UnityEngine;
using TMPro;
using AK.Wwise;

public class Interaction_phone : MonoBehaviour
{
    public string eventName;
    public string textToDisplay;
    public GameObject interactUI;
    public GameObject phoneHandSet;
    public GameObject phoneRinging;
    //public GameObject phoneDialTone;
    public TextMeshProUGUI interactText;
    private bool playerInRange = false;
    private bool phoneHandSetEnabled = false;
    public int transitionDuration = 0;

    private void Start()
    {
        if (interactUI != null)
        {
            interactUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopAudioFile();
                AkSoundEngine.PostEvent(eventName, gameObject);
                
                //TogglePhoneHandset();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactUI != null)
            {
                interactUI.SetActive(true);
                if (interactText != null)
                {
                    interactText.text = textToDisplay;
                }
   
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactUI != null)
            {
                interactUI.SetActive(false);
            }
        }
    }

    private void StopAudioFile()
    {
        if (phoneRinging != null)
        {
            AkAmbient akAmbient = phoneRinging.GetComponent<AkAmbient>();
            if (akAmbient != null)
            {
                akAmbient.Stop(transitionDuration);
            }
            else
            {
                Debug.LogError("AkAmbient component not found on the game object!");
            }
        }
        else
        {
            Debug.LogError("AkAmbient game object reference is missing!");
        }
    }
    //private void TogglePhoneHandset()
    //{
    //    if (phoneHandSet != null)
    //    {
    //        phoneHandSetEnabled = !phoneHandSetEnabled;
    //        phoneHandSet.SetActive(phoneHandSetEnabled);
    //        phoneDialTone.SetActive(true);
    //    }
    //}


}