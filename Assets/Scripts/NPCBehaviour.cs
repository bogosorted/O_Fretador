using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour, Iinteractable
{
    public string[][] dialogues = {new string[] {"default text", "olá viajante bla bla fodasse", "próximo diálogo e talz", "pipipi popopo"},
                                   new string[] {"default text after mission", "aah vlw troxa ajuda nice", "diálogo no meio", "pipipipopopo fim"}};
    public int cmi = 0;
    private bool newChat = true, typing = false, onChat = false;

    [SerializeField]private Texture2D ownIcon;
    [SerializeField]private string triggerKey;
    [SerializeField]private Player player;

    [SerializeField] private GameObject dialogueBox;
    private RawImage dialogueIcon;
    private Text chatText;
    
    void Awake(){
        chatText = dialogueBox.transform.GetChild(0).GetComponent<Text>();
        dialogueIcon = dialogueBox.transform.GetChild(1).GetComponent<RawImage>();
    }

    void Update()
    {
        // if(Input.GetKeyDown(triggerKey) && !onChat){
        //     StartCoroutine("NPCDialogue");
        // }
        if(Input.GetKeyDown(KeyCode.Q)){
            cmi++;
            newChat = true;
        }
    }

    public void Interact() {
        if(!onChat){
            StartCoroutine("NPCDialogue");
        }
    }

    public IEnumerator NPCDialogue(){
        player.movable = false;
        yield return new WaitForEndOfFrame();
        dialogueIcon.texture = ownIcon;
        dialogueBox.SetActive(true);
        onChat = true;
        if(newChat) {
            for(int i = 1; i < dialogues[cmi].Length; i++){
                var currentTyping = StartCoroutine(PrintDialogue(dialogues[cmi][i]));
                yield return WaitForKeyDown(KeyCode.Space);
                if(typing) {
                    StopCoroutine(currentTyping);
                    chatText.text = dialogues[cmi][i];
                    yield return new WaitForEndOfFrame();
                    yield return WaitForKeyDown(KeyCode.Space);
                }
                yield return new WaitForEndOfFrame();
            }
            newChat = false;
        }
        else{
            var currentTyping = StartCoroutine(PrintDialogue(dialogues[cmi][0]));
            yield return WaitForKeyDown(KeyCode.Space);
            if(typing) {
                StopCoroutine(currentTyping);
                chatText.text = dialogues[cmi][0];
                yield return new WaitForEndOfFrame();
                yield return WaitForKeyDown(KeyCode.Space);
            }
            yield return new WaitForEndOfFrame();
        }
        dialogueBox.SetActive(false);
        onChat = false;
        player.movable = true;
    }

    public IEnumerator PrintDialogue(string message){
        typing = true;
        chatText.text = "";
        foreach(char letter in message) {
            chatText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        typing = false;
    }

    public IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }

}
