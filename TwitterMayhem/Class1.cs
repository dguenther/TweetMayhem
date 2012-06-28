using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MayhemCore;
using System.Runtime.Serialization;
using MayhemWpf.ModuleTypes;
using MayhemWpf.UserControls;
using System.Windows;
using TweetSharp;

namespace TweetMayhem
{
    [DataContract]
    [MayhemModule("Twitter: Post Tweet", "Posts a tweet to Twitter")]
    public class PostTweet : ReactionBase, IWpfConfigurable
    {
        [DataMember]
        private string status;

        [DataMember]
        private string username;

        [DataMember]
        private string oauthToken;

        [DataMember]
        private string accessToken;

        public override void Perform()
        {
            TwitterService service = new TwitterService(TweetMayhem.Properties.Resources.ConsumerKey, TweetMayhem.Properties.Resources.ConsumerSecret);
            service.AuthenticateWith(accessToken, oauthToken);
            service.SendTweet(this.status);
        }

        public WpfConfiguration ConfigurationControl
        {
            get { return new TweetConfig(status, username, oauthToken, accessToken); } 
        }
        
        public void OnSaved(WpfConfiguration configurationControl)
        {
            status = ((TweetConfig)configurationControl).Status;
            username = ((TweetConfig)configurationControl).Username;
            oauthToken = ((TweetConfig)configurationControl).OAuthToken;
            accessToken = ((TweetConfig)configurationControl).AccessToken;
        }

        public string GetConfigString()
        {
            return string.Format("Tweet \"{0}\"", status);
        }
    }
}
