using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class fade1 : MonoBehaviour
{
    private int switching = 0;
    private string mmscene2;
    private float timer = 1;
    private Animator fadeout;
    private Animator UIfadeout;
    public GameObject mmenufadeout;
    public GameObject mmfadeUI;
    public void MMBClicked(string mmbscene)
    {
        switching = 1;
        mmscene2 = mmbscene;
        mmenufadeout = GameObject.Find("Menu");
        fadeout = mmenufadeout.GetComponent<Animator>();
        UIfadeout = mmfadeUI.GetComponent<Animator>();
    }
    void Update()
    {
        if (switching == 1)
        {
            fadeout.Play("Menu_FadeOut");
            UIfadeout.Play("MenuUIFadeOut");
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(mmscene2);
            }
        }
    }
}
