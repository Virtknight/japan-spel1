using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    [SerializeField] public Queue<Quest> queue;
    public Queue<Quest> QuestsInOrder;

    // Update is called once per frame
    void Start()
    {
        AddQuestList();
    }

    private void AddQuestList()
    {
        foreach (Quest quest in QuestsInOrder)
        {
            queue.Enqueue(quest);
        }
    }

    public void RemoveFromList()
    {
        queue.Dequeue();
    }

    public void ChangeDisplayed()
    {

    }
    public void CheckForRemoval()
    {
        if (QuestsInOrder.Peek() != null)
        {
            Quest first = QuestsInOrder.Peek();
            if(first.finished == true){
                RemoveFromList();
            }
        }



    }
}
