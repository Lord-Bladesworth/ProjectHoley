using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base boxclass
[RequireComponent(typeof(Rigidbody))]
public abstract class BoxClass : MonoBehaviour
{
    [SerializeField]
    protected int Level = 1;
   
    protected Rigidbody body;
    public int GetLevel { get { return Level; } }
    public abstract void InitializeBox();
    
    private Vector3 OriginalPosition;

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeAll;
        OriginalPosition = transform.position;
        GetComponent<Collider>().isTrigger = true;
    }
    // Start is called before the first frame update
    void Start()
    {
       GameManager.SubscribeToPool(gameObject);
        InitializeBox();
    }
    
    // Update is called once per frame
    protected virtual void OnUpdate()
    {
        
    }
    private void Update()
    {
        OnUpdate();
    }

    public abstract void OnDiskEntry(bool IsEntry);
    public abstract void OnHoleEntry();
    protected void ObjectDisable()
    {
        StartCoroutine("Disable");
    }
    protected virtual void ForcedDisable()
    {
        gameObject.SetActive(false);
    }
    public virtual void ResetGameObject()
    {
        transform.position = OriginalPosition;
        gameObject.layer = 0;
        gameObject.SetActive(true);
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(GameManager.TimetoDisable);
        gameObject.SetActive(false);
    }
    

}
