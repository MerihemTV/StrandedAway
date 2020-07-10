public class Chest : Interactable
{
    public override void  interact()
    {
        ChestInventoryUI.instance.openChest();
    }
}
