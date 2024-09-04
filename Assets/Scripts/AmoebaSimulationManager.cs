using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmoebaSimulationManager : MonoBehaviour
{
    #region Attributes

    [Header("Refrennces")]
    public GameObject[] PickableObjects;
    public BoxCollider[] colliders;
    public Animator[] animators;
    public int step;
    public static AmoebaSimulationManager ins;

    [Header("Cursor")]
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 cursorOffset;
    public Texture2D handCursor;

    [Header("Clamp")]
    float[] zClamp;
    float[] yClamp;
    [SerializeField]
    GameObject XSlip, YSlip, ZSlip;

    [Header("Animation Events")]
    public GameObject dropX;
    public GameObject dropY, dropZ;
    public GameObject rui;
    public Material finalWhiteThing;

    [Header("Camera Zoom")]
    public GameObject[] allSlides;
    public GameObject microscopeCanvas;
    public Image image;
    public Sprite []sprite;


    [Header("BloodDRIPS")]
    public GameObject[] drops;
    public GameObject hand;
    #endregion


    #region Monobehaviour Functions
    void Awake()
    {
        ins = this;
        //adding triggering script to colliding objs
        foreach (BoxCollider box in colliders)
        {
            AmoewbaColiderBridge cb = box.gameObject.AddComponent<AmoewbaColiderBridge>();
            cb.Initialize(this);
        }

        //disabling all animators initially
        foreach (Animator anim in animators)
            anim.enabled = false;

        //disabling all colliders initially
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = false;
            collider.isTrigger = true;
        }

    }


    private void Start()
    {
        step = 0;
        colliders[step].enabled = true;
        //      PickableObjects[5].GetComponent<BurnerClick>().enabled = false;
        //PickableObjects = null;
        zClamp = new float[PickableObjects.Length];
        yClamp = new float[PickableObjects.Length];
        //PickableObjects[10].GetComponent<BoxCollider>().enabled = false;

        for (int i = 0; i < zClamp.Length; i++)
        {
            zClamp[i] = PickableObjects[i].transform.localPosition.z;
        }

        for (int i = 0; i < yClamp.Length; i++)
        {
            yClamp[i] = PickableObjects[i].transform.localPosition.y;
        }

        //thermometerCanvas.SetActive(false);
        //   finalWhiteThing.color = new Color(finalWhiteThing.color.r, finalWhiteThing.color.g, finalWhiteThing.color.b, 0);
        // colliders[5].gameObject.SetActive(false);

        microscopeCanvas.SetActive(false);
        image.sprite = sprite[0];

    }


    private void Update()
    {
        //for (int i = 0; i < PickableObjects.Length; i++)
        //{

        //    PickableObjects[i].transform.localPosition = new Vector3(PickableObjects[i].transform.localPosition.x, PickableObjects[i].transform.localPosition.y, zClamp[i]);

        //    if (PickableObjects[i].transform.localPosition.y < yClamp[i])
        //        PickableObjects[i].transform.localPosition = new Vector3(PickableObjects[i].transform.localPosition.x, yClamp[i], PickableObjects[i].transform.localPosition.z);
        //}
        //  Debug.Log(x);
    }



    public void OnCollisionEnter(Collision collision)
    {
        // Do your stuff here
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        switch (step)
        {
            case 0:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("slideXtoCamAmoeba");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
               // StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 1:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("XonBlood");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 2:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("YSlideWater");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 3:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("YonBlood");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 4:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("ZSlideWater");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 5:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("ZonBlood");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 6:
                XSlip.SetActive(true);
                colliders[step].gameObject.SetActive(false);
                PickableObjects[step].SetActive(false);
                StartCoroutine(NextStepsProcedures(1));


                break;
            case 7:
                YSlip.SetActive(true);
                colliders[step].gameObject.SetActive(false);
                PickableObjects[step].SetActive(false);
                StartCoroutine(NextStepsProcedures(1));
                // colliders[8].gameObject.SetActive(true);
                break;
            case 8:
                ZSlip.SetActive(true);
                colliders[step].gameObject.SetActive(false);
                PickableObjects[step].SetActive(false);
                StartCoroutine(NextStepsProcedures(1));


                break;
            case 9:
                EnableAndPlayAnimation();


                break;
            case 10:
                EnableAndPlayAnimation();
                //StartCoroutine(NextStepsProcedures(1));
                Debug.Log("hhi2 " + other.name);
                break;
            case 11:
                EnableAndPlayAnimation();
                //StartCoroutine(NextStepsProcedures(1));
                break;
            case 12:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("HandFirstPlace");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 13:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("ZneedlePress");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 14:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("HandSecPlace");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 15:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("YneedlePress");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 16:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("HandThrdPlace");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f));
                break;
            case 17:
                animators[step].enabled = true;
                colliders[step].gameObject.SetActive(false);
                animators[step].Play("XneedlePress");
                PickableObjects[step].GetComponent<BoxCollider>().enabled = false;
                Destroy(PickableObjects[step].GetComponent<AmoebaObjectPicker>());
                //      Cursor.SetCursor(null, Vector2.zero, SimulationManager.ins.cursorMode);
                StartCoroutine(turnOffAnimator(animators[step], 1.8f));
                StartCoroutine(NextStepsProcedures(1.8f, 0));

                break;
        }

    }
    //agar auto chale to matalb collider kahee hit horaha he

    public IEnumerator NextStepsProcedures(float t)
    {
        PickableObjects[step].GetComponent<BoxCollider>().enabled = false;

        PickableObjects[step].GetComponent<AmoebaObjectPicker>().enabled = false;
        Cursor.SetCursor(null, Vector2.zero, AnimalCell_SimulationManager.ins.cursorMode);
        yield return new WaitForSecondsRealtime(t);

        if (step < colliders.Length)
            step++;

        colliders[step].enabled = true;
        colliders[step].gameObject.SetActive(true);
        Debug.Log("hiss");
        PickableObjects[step].AddComponent<AmoebaObjectPicker>();
        Debug.Log("asdad");
        PickableObjects[step].GetComponent<BoxCollider>().enabled = true;
    }
    public IEnumerator NextStepsProcedures(float t, int x)
    {
        PickableObjects[step].GetComponent<BoxCollider>().enabled = false;

        PickableObjects[step].GetComponent<AmoebaObjectPicker>().enabled = false;
        Cursor.SetCursor(null, Vector2.zero, AnimalCell_SimulationManager.ins.cursorMode);
        yield return new WaitForSecondsRealtime(t);

        if (step < colliders.Length)
            step = x;

        colliders[step].enabled = true;
        colliders[step].gameObject.SetActive(true);
        Debug.Log("hiss");
        PickableObjects[step].AddComponent<AmoebaObjectPicker>();
        Debug.Log("asdad");
        PickableObjects[step].GetComponent<BoxCollider>().enabled = true;
    }

    #endregion

    private IEnumerator turnOffAnimator(Animator anim, float x)
    {
        yield return new WaitForSecondsRealtime(x);
        anim.enabled = false;
    }
    public void ResetButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void EnableAndPlayAnimation()
    {
        animators[step].enabled = true;
        colliders[step].gameObject.SetActive(false);
        animators[step].SetTrigger("Play");

    }

    public void CamAnimation()
    {
        PickableObjects[step].GetComponent<AmoebaObjectPicker>().enabled = false;
        Camera.main.GetComponent<Animator>().Play("CameraZoom");
    }

    #region Image Zoom Code

    #endregion

    public void BTNBack()
    {
        microscopeCanvas.SetActive(false);
        Camera.main.GetComponent<Animator>().Play("CameraReverse");

        Invoke(nameof(ReverseSlideAnimation), 1);
    }

    private void ReverseSlideAnimation()
    {
        allSlides[AnimalCell_AnimationsEvents.imageType].GetComponent<Animator>().Play("MicroScopetoTable" + AnimalCell_AnimationsEvents.imageType);
    }

    public void BTNRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    int _currentSprite = 0;
    [SerializeField]
    GameObject backButton;
    public void NeckstImage()
    {
            image.sprite = sprite[++_currentSprite];
   
        if (_currentSprite >= sprite.Length-1)
            backButton.SetActive(false);
    }


}
