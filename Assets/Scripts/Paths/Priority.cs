using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T>
{
    private List<KeyValuePair<T, float>> elements = new List<KeyValuePair<T, float>>();

    public int Count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add(new KeyValuePair<T, float>(item, priority));
    }

    public T Dequeue()
    {
        var bestIndex = 0;
        for (var i = 0; i < elements.Count; i++)
        {
            if (elements[i].Value < elements[bestIndex].Value)
                bestIndex = i;
        }
        var bestItem = elements[bestIndex].Key;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }

    public bool Contains(T item)
    {
        return elements.Any(element => EqualityComparer<T>.Default.Equals(element.Key, item));
    }
}