using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

    public Color TrueColor;
    private MemoryManager Manager;
    public Animator Anim;

	// Use this for initialization
	void Start () {
	   Manager = GameObject.Find("MemoryManager").GetComponent<MemoryManager>();
       SetColor(Manager.DefaultColor);
       Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnMouseDown() {
        if (!Manager.IsWaiting) {
            SetColor(TrueColor);
            Anim.SetBool("Selected", true);
            Manager.CubeClicked (this);
        }
    }

    public void SetColor(Color NewColor) {
        GetComponent<Renderer>().material.color = NewColor;
    }
}
