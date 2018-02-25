using System.Collections.Generic;
using System.Linq;

namespace WavecellSmsDeliveryReports.Models
{
    public class MessagesMq
    {
        private static object _lock = new object();
        private static List<string> _messages;

        public MessagesMq()
        {
            lock (_lock)
            {
                if (_messages == null)
                {
                    _messages = new List<string>();
                }
            }
        }

        public void Add(string message)
        {
            lock (_lock)
            {
                _messages.Add(message);
            }
        }

        public IList<string> Consume()
        {
            List<string> toRet = null;
            lock (_lock)
            {
                if (_messages.Count > 0)
                {
                    toRet = _messages.Select(item => (string) item.Clone()).Reverse().ToList();
                    _messages.Clear();
                }
            }
            return toRet;
        }
    }
}
