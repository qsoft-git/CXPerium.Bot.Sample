namespace CXPerium.Bot.Template.Dialogs
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
