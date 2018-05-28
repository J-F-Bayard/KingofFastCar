using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.Mediator
{
    public class Message<TContent>
    {
        private TContent _Content;

        public Message(TContent Content)
        {
            this.Content = Content;
        }

        public TContent Content
        {
            get
            {
                return _Content;
            }

            private set
            {
                _Content = value;
            }
        }
    }
}
