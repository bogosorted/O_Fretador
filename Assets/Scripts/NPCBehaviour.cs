using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour, Iinteractable
{
    private string[][] dialogues = {new string[] {"Aha, você deve ser o novo barqueiro que veio ajudar \ncom as entregas", 
                                                 "Prazer, o meu nome é Jorel, eu sou o encarregado de \nte passar os serviços que você vai cumprir", 
                                                 "Você é bem corajoso de aceitar esse trabalho \nessas águas são muito perigosas",
                                                 "Tem vários piratas pela região, além de ter algumas \npedras que atrabalham na navegação",
                                                 "Mas tenho certeza que você é habilidoso o bastante \npra dar conta do recado",
                                                 "Mas chega de enrolação, o seu primeiro trabalho \nnão vai ser tão complexo",
                                                 "Apenas preciso que entregue esses suprimentos pra \nilha que fica ao Norte daqui"},
                                    new string[]{"Vejo que você conseguiu entregar tudo com sucesso, \nbom trabalho!",
                                                 "Agora que já aprendeu como o trabalho funciona eu vou \nte deixar responsável por cada vez mais ilhas",
                                                 "A próxima fica ao Direção da primeira ilha", 
                                                 "Passe primeiro pela ilha ao Norte para reabastecê-la \nnovamente e depois parta para a próxima ao Direção",
                                                 "Você terá que manter esse ciclo, e a quantidade de \nilhas vai aumentar enquanto você der conta do trabalho",
                                                 "E não se preocupe, seu barco será reparado sempre \nque você passar por aqui",
                                                 "Você pode partir agora, boa sorte"},
                                    new string[]{"Bom trabalho! \nA próxima ilha fica ao Direção da última."}};
    private string[] defaultTips =  new string[]{"Os canhões de seu barco são ótimos para se proteger \nponha bolas de canhão e mande os piratas pra longe",
                                                 "Quando ver uma pedra a frente, tente esquivar dela \nutilizando o timão",
                                                 "Rachaduras vão se abrir no seu barco se ele sofrer \nmuitos danos, repare elas para não afundar"};
    private int tipIndex = 0;
    public int cmi = 0;
    private bool newChat = true, typing = false, onChat = false;

    [SerializeField]private Texture2D ownIcon;
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
            for(int i = 0; i < dialogues[cmi].Length; i++){
                var currentTyping = StartCoroutine(PrintDialogue(dialogues[cmi][i]));
                yield return WaitForKeyDown(KeyCode.Space);
                if(typing) {
                    StopCoroutine(currentTyping);
                    // string wholeMsg = dialogues[cmi][i].Replace("$", "\n");
                    chatText.text = dialogues[cmi][i];
                    yield return new WaitForEndOfFrame();
                    yield return WaitForKeyDown(KeyCode.Space);
                }
                yield return new WaitForEndOfFrame();
            }
            newChat = false;
        }
        else{
            var currentTyping = StartCoroutine(PrintDialogue(defaultTips[tipIndex]));
            yield return WaitForKeyDown(KeyCode.Space);
            if(typing) {
                StopCoroutine(currentTyping);
                chatText.text = defaultTips[tipIndex];
                yield return new WaitForEndOfFrame();
                yield return WaitForKeyDown(KeyCode.Space);
            }
            tipIndex = (tipIndex + 1 == defaultTips.Length) ? 0 : tipIndex + 1;
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
            // if(letter == '$'){
            //     chatText.text += "\n";
            //     continue;
            // }
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
