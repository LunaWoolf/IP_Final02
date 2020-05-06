using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioSource theMusic;

    public bool start;

    public BeatScroller beatScro;

    public static GameController instance;

    public int curScore;
    public int scorePreNote = 100;

    public int curCombo = 1;
    public int comboTracker;
    public int[] combo;

    public GameObject noteSheet;
    public GameObject leftkey;
    public Vector3 leftnotepos;

    public GameObject scoretext;
    public GameObject combotext;

    void Start()
    {
        instance = this;

    }

    
    void Update()
    {
        if (!start)
        {
            if (Input.anyKeyDown)
            {
                start = true;
                beatScro.start = true;

                theMusic.Play();
                StartCoroutine(GenerateNote());
            }
        }
       
    }

    private IEnumerator GenerateNote()
    {
        while (start)
        {
            
            yield return new WaitForSeconds(beatScro.bpm/2);
            GameObject newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
            newNote.transform.position = leftnotepos;
        }
        

    }
    public void NoteHit()
    {
        curCombo++;
        curScore += scorePreNote * curCombo;
        scoretext.GetComponent<Text>().text = "" + curScore;
        combotext.GetComponent<Text>().text = "" + curCombo;
    }

    public void NoteMiss()
    {
        //curCombo = 0;
    }
}
