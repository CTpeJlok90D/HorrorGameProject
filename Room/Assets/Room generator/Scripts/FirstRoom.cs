public class FirstRoom : Room
{
    protected void Awake()
    {
        GenerateNextRooms(this);
    }
}
