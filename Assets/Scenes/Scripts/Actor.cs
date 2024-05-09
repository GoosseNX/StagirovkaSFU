using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    public UnityEvent OnActivateAction;
    public UnityEvent OffActivateAction;
    

    
    public void StartAction()
    {
        OnActivateAction.Invoke();
    }
    public void StopAction()
    {
        OffActivateAction.Invoke();
    }
}