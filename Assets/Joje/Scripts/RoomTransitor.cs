using Eflatun.SceneReference;
using UnityEngine.SceneManagement;

namespace Joje.Scripts
{
    public class RoomTransitor : Unlockable
    {
        public SceneReference roomToEnter;

        public void EnterRoom()
        {
            if (!isLocked)
            {
                SceneManager.LoadScene(roomToEnter.BuildIndex);
                print("Entered " + roomToEnter);
            }
            else
            {
                print(roomToEnter + " is Locked");
            }
        }
    }
}