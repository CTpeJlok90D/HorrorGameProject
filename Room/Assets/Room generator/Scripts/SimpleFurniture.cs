using System;

public class SimpleFurniture : Furniture
{
    protected override Furniture OnInit(RoomFurnitureList roomFurnitureList)
    {
        roomFurnitureList.AddSimpleFurniture(this.gameObject);
        return this;
    }
}
