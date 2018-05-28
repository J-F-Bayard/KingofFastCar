using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.Mediator
{
    public class Messenger<TMessage, TContent>
        where TMessage : Message<TContent>
    {
        private Action<TMessage> _Broadcast;

        public void Register(Action<TMessage> Method)
        {
            if (Method == null)
            {
                throw new ArgumentNullException(nameof(Method));
            }
            _Broadcast += Method;
        }
        public void Unregister(Action<TMessage> Method)
        {
            if (Method == null)
            {
                throw new ArgumentNullException(nameof(Method));
            }
            _Broadcast -= Method;
        }
        public void Send(TMessage Message)
        {
            _Broadcast?.Invoke(Message);
        }
    }
}
