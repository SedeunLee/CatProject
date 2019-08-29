using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClickCls : MonoBehaviour
{
    public Camera camera;
    private GameObject catIta;
    private GameObject itemListUI;
    private GameObject itemDescUI;
    private GameObject catInfoUI;
    private Transform target;
    public int catUICount;

    public int setcamera = 0;

    private GameObject raycat = null;
    private GameObject mainuimgr;
    private GameObject mainbtn;

    void CatUIOnOff()
    {
        if (catUICount % 2 == 1)
        {
            catIta.SetActive(true);
        }
        else
        {
            catIta.SetActive(false);
        }
    }
    void CatClick()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log("Shoot the Ray");
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Shoot the Ray2");
            // the object identified by hit.transform was clicked
            // do whatever you want
            if (hit.collider.tag == "Cat")
            {
                Debug.Log("maw?");

                Vector3 screenPos = camera.WorldToScreenPoint(hit.rigidbody.position);

                float x = screenPos.x;

                catIta.transform.position = new Vector3(x, screenPos.y, catIta.transform.position.z);

                catUICount++;

                raycat = hit.collider.gameObject;
            }
        }
    }
    void InitializeMyFuntion()
    {
        catIta = GameObject.Find("CatIta");
        itemListUI = GameObject.Find("ItemUI");
        itemDescUI = GameObject.Find("ItemDescUI") ;
        catInfoUI = GameObject.Find("CatInfoUI");

        catUICount = 0;
        itemListUI.SetActive(false);
        itemDescUI.SetActive(false);
        catInfoUI.SetActive(false);

        mainuimgr = GameObject.Find("MainUIMgr");
        mainbtn = GameObject.Find("Main");
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeMyFuntion();
    }

    // Update is called once per frame
    void Update()
    {
        if (setcamera == 0)
        {
            if (Input.GetMouseButtonDown(0)) CatClick();

            CatUIOnOff();
        }
        else
        {
            if (catUICount % 2 != 0)
                catUICount++;

            CatUIOnOff();
        }
    }

    public void OnTouchBye()
    {
        GameObject.Find("Information").gameObject.SetActive(false);

        if (raycat != null)
        {
            GameObject.Find("CatInfoUI").gameObject.SetActive(false);
            Destroy(raycat);
            mainuimgr.SetActive(true);
            mainbtn.SetActive(true);
        }
    }
}