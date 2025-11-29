using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager instance;

    public int collectedTrash = 0;
    public int requiredTrash = 5;

    private void Awake()
    {
        instance = this;
    }

    public void AddTrash()
    {
        collectedTrash++;
        Debug.Log("AddTrash dipanggil oleh: " + 
                  (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name);

        TrashBarController.instance.UpdateBar(collectedTrash, requiredTrash);
    }

    private void Start()
    {
        TrashBarController.instance.UpdateBar(collectedTrash, requiredTrash);
    }
}
