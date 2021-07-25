using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
    static public Text chatText;
    static public GameObject dialogueBox;
    static public RawImage dialogueIcon;
    static public bool onChat = false;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueBox = GameObject.FindWithTag("DialogueBox");
        chatText = dialogueBox.transform.GetChild(0).GetComponent<Text>();
        dialogueIcon = dialogueBox.transform.GetChild(1).GetComponent<RawImage>();
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
