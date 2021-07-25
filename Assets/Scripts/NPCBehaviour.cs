using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour
{
    public string[][] dialogues = {new string[] {"default text", "olá viajante bla bla fodasse", "próximo diálogo e talz", "pipipi popopo"},
                                   new string[] {"default text after mission", "aah vlw troxa ajuda nice", "diálogo no meio", "pipipipopopo fim"}};
    public int cmi = 0;
    private bool newChat = true, typing = false;

    [SerializeField]private Texture2D ownIcon;
    [SerializeField]private string triggerKey;
    
    void Awake(){
    }

    void Update()
    {
        if(Input.GetKeyDown(triggerKey) && !DialogueUIController.onChat){
            StartCoroutine("NPCDialogue");
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            cmi++;
            newChat = true;
        }
    }

    public IEnumerator NPCDialogue(){
        DialogueUIController.dialogueIcon.texture = ownIcon;
        DialogueUIController.dialogueBox.SetActive(true);
        DialogueUIController.onChat = true;
        if(newChat) {
            for(int i = 1; i < dialogues[cmi].Length; i++){
                var currentTyping = StartCoroutine(PrintDialogue(dialogues[cmi][i]));
                yield return WaitForKeyDown(KeyCode.Space);
                if(typing) {
                    StopCoroutine(currentTyping);
                    DialogueUIController.chatText.text = dialogues[cmi][i];
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
                DialogueUIController.chatText.text = dialogues[cmi][0];
                yield return new WaitForEndOfFrame();
                yield return WaitForKeyDown(KeyCode.Space);
            }
            yield return new WaitForEndOfFrame();
        }
        DialogueUIController.dialogueBox.SetActive(false);
        DialogueUIController.onChat = false;
    }

    public IEnumerator PrintDialogue(string message){
        typing = true;
        DialogueUIController.chatText.text = "";
        foreach(char letter in message) {
            DialogueUIController.chatText.text += letter;
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
