using CXPerium.Controller.WebHook;
using CXPerium.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
