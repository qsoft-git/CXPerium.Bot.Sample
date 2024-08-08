using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CXPerium.Bot.Template.Channels
{
    [Route("api/whatsapp")]
    public class WhatsappController : WpBaseController
    {
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] WhatsappMessage message)
        {
            if (message.Messages != null)
            {
                _ = Task.Run(() => ProcessMessage(message)).ConfigureAwait(false);
            }

            return Task.FromResult<ActionResult>(Ok());
        }

        /// <summary>
        /// If this feature is active, the method is triggered. 
        /// For detailed information, visit https://developers.facebook.com/docs/whatsapp/cloud-api/phone-numbers/conversational-components/#using-the-api
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activity">It contains information about the message, such as a form, file or text message.</param>
        public override void OnWelcomeReceived(Models.Contact contact, Activity activity)
        {
            base.OnWelcomeReceived(contact, activity);
        }


        /// <summary>
        /// It translates the data in the Contacts records of the user who sent the message. You can add different data by overriding this method. 
        /// For example, you can add information you get from the database to Attributes.
        /// </summary>
        /// <param name="phone">Phone number of the message sender</param>
        /// <param name="profileName">Whatsapp profile name of message sender</param>
        /// <param name="attributes">Custom fields defined on the user</param>
        /// <returns>Translates contact information in CXPerium</returns>
        public override CXPerium.Models.Contact GetContactByPhone(
            string phone,
            string profileName,
            Dictionary<string, string> attributes
        )
        {
            return base.GetContactByPhone(phone, profileName, attributes);
        }


        /// <summary>
        /// This method is triggered when the message written by the user is captured by DialogFlow.
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activity">It contains information about the message, such as a form, file or text message.</param>
        /// <param name="conversationState">Class that contains information about the conversation</param>
        /// <param name="fullFilment">Response returned from DialogFlow</param>
        public virtual void OnDialogFlowMessage(Models.Contact contact, Activity activity, ConversationState conversationState, string fullFilment)
        {
            base.OnDialogFlowMessage(contact, activity, conversationState, fullFilment);
        }


        /// <summary>
        /// This method is triggered when the message written by the user is captured by DialogFlow.
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activity">It contains information about the message, such as a form, file or text message.</param>
        /// <param name="conversationState">Class that contains information about the conversation</param>
        /// <param name="fullFilment">Response returned from DialogFlow</param>
        public virtual void OnChatGPTMessage(Models.Contact contact, Activity activity, ConversationState conversationState, string response, List<AnnotationFile> annotations)
        {
            base.OnChatGPTMessage(contact, activity, conversationState, response,annotations);
        }

        /// <summary>
        /// This method is triggered when the message cannot find any response in NLP engines.
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activity">It contains information about the message, such as a form, file or text message.</param>
        /// <param name="conversationState">Class that contains information about the conversation</param>
        public override void OnUnderstandMessage(
            CXPerium.Models.Contact contact,
            Activity activity,
            ConversationState conversationState
        )
        {
            base.OnUnderstandMessage(contact, activity, conversationState);
        }

        /// <summary>
        /// The method is triggered when the user sends any file, image, etc.
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activiy">It contains information about the message, such as a form, file or text message.</param>
        /// <param name="conversationState">Class that contains information about the conversation. For example, conversation language, conversation session information, etc.</param>
        public override void OnFileReceived(
            CXPerium.Models.Contact contact,
            Activity activiy,
            ConversationState conversationState
        )
        {
            base.OnFileReceived(contact, activiy, conversationState);
        }

        /// <summary>
        /// This method is triggered when the user sends their cart to the business
        /// </summary>
        /// <param name="contact">Data of the user who sent the message in the Contacts list in CXPerium</param>
        /// <param name="activiy">It contains information about the message, such as a form, file or text message.</param>
        /// <param name="conversationState">Class that contains information about the conversation. For example, conversation language, conversation session information, etc.</param>
        public override void OnOrderReceived(
            CXPerium.Models.Contact contact,
            Activity activiy,
            ConversationState conversationState
        )
        {
            base.OnOrderReceived(contact, activiy, conversationState);
        }
    }
}
