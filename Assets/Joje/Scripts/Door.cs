namespace Joje.Scripts
{
    public class Door : RoomTransitor
    {
        private void OnMouseDown()
        {
            if (this.enabled == false)
            {
                return;
            }
            EnterRoom();
        }
    }
}