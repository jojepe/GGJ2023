using System.Collections;

namespace Joje.Scripts
{
    public interface IFader
    {
        public IEnumerator FadeCoroutine();
    }
}