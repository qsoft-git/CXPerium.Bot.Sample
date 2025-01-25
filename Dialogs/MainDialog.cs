using CXPerium.Dialogs.WhatsApp;
using CXPerium.Models;
using CXPerium.WhatsApp;

namespace CXPerium.Bot.Sample.Dialogs
{
    public class MainDialog : WelcomeDialog
    {
    
        public override void RunDialog()
        {
            this.Messages.SendMessage("Hello World");
        }
    }
}
