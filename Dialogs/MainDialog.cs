using CXPerium.Dialogs.WhatsApp;
using CXPerium.Models;
using CXPerium.WhatsApp;

namespace CXPerium.Bot.Sample.Dialogs
{
    public class MainDialog : WelcomeDialog
    {
        public MainDialog(Models.Contact contact, Activity activity, ConversationState conversation)
            : base(contact, activity, conversation) { }

        public override void RunDialog()
        {
            SendMessage("Hello World");
        }
    }
}
