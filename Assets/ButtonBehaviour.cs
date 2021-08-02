using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]FadeSystemBehaviour fade;
    
    public void OnPlay()
    {
        StartCoroutine(WaitFade());
    }
    IEnumerator WaitFade()
    {
        fade.CreateFade(false,1,Random.Range(0,fade.TypesF.Length));
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
