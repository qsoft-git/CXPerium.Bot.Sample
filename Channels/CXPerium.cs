using CXPerium.Controller.WebHook;
using CXPerium.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CXPerium.Bot.Sample.Channels
{
    [Route("api/cxlive/webhook")]
    [Route("api/cxperium/webhook")]
    public class CXPerium : CXPeriumHook
    {
        protected override void OnSurveyQuestionAnswered(Contact contact, ConversationState conversation, SurveyCx survey, SurveyQuestionReplyCx answer)
        {
            base.OnSurveyQuestionAnswered(contact, conversation, survey, answer);
        }

        protected override void OnSurveyComplated(Contact contact, ConversationState conversation, SurveyCx survey)
        {
            base.OnSurveyComplated(contact, conversation, survey);
        }
        protected override void OnSessionTimeOut(Contact contact, ConversationState conversation)
        {
            base.OnSessionTimeOut(contact, conversation);
        }

        protected override void OnClosingLiveChat(Contact contact)
        {
            base.OnClosingLiveChat(contact);
        }
    }
}
