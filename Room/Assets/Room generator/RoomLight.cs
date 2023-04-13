public class RoomLight : Furniture
{
    protected override Furniture OnInit(RoomFurnitureList roomFurnitureList)
    {
        roomFurnitureList.AddLight(this.gameObject);
        return this;
    }
}