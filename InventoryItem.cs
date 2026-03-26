[System.Serializable]
public class InventoryItem
{
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData item)
    {
        data = item;
        AddToStack();
    }

    public void AddToStack() => stackSize++;
    public void RemoveFromStack() => stackSize--;
}
