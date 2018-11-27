using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRemote;

namespace Server
{
    public class Factory : MarshalByRefObject , IFactory
    {
        IMailBox IFactory.getNewMailBox()
        {
            return (MailBox) new MailBox();
        }
    }
}
