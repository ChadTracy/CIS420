using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace AHA_Web.MailChimp
{
    public class MailChimp
    {
        private string apiKey = "1ef091748606da4e95c914f34c8c74bc-us14";
        private string baseUri = "https://us14.api.mailchimp.com/3.0";
        private string username = "ahaadmn";

        private void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }

        private string getWebResponseJson(string url)
        {
            var request = WebRequest.Create(url);
            SetBasicAuthHeader(request, username, apiKey);

            //var response = request.GetResponse();
            string jsonText = "";
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    jsonText = reader.ReadToEnd();
                }
                response.Close();
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    //log errorText
                }
                errorResponse.Close();
                throw;
            }
            return jsonText;
        }

        #region Random Shit
        //Used to create an MD5 hash
        private string GetMD5Hash(string input)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        #endregion Random Shit

        public AllLists getLists()
        {
            var response = getWebResponseJson(baseUri + "/lists");

            //Read data from stream
            var JSS = new JavaScriptSerializer();
            AllLists lists = JSS.Deserialize<AllLists>(response);

            return lists;
        }
    }

    #region Lists Classes
    public class Contact
    {
        public string company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
    }

    public class CampaignDefaults
    {
        public string from_name { get; set; }
        public string from_email { get; set; }
        public string subject { get; set; }
        public string language { get; set; }
    }

    public class Stats
    {
        public int member_count { get; set; }
        public int unsubscribe_count { get; set; }
        public int cleaned_count { get; set; }
        public int member_count_since_send { get; set; }
        public int unsubscribe_count_since_send { get; set; }
        public int cleaned_count_since_send { get; set; }
        public int campaign_count { get; set; }
        public string campaign_last_sent { get; set; }
        public int merge_field_count { get; set; }
        public int avg_sub_rate { get; set; }
        public int avg_unsub_rate { get; set; }
        public int target_sub_rate { get; set; }
        public int open_rate { get; set; }
        public int click_rate { get; set; }
        public string last_sub_date { get; set; }
        public string last_unsub_date { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string method { get; set; }
        public string targetSchema { get; set; }
        public string schema { get; set; }
    }

    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public string permission_reminder { get; set; }
        public bool use_archive_bar { get; set; }
        public CampaignDefaults campaign_defaults { get; set; }
        public string notify_on_subscribe { get; set; }
        public string notify_on_unsubscribe { get; set; }
        public string date_created { get; set; }
        public int list_rating { get; set; }
        public bool email_type_option { get; set; }
        public string subscribe_url_short { get; set; }
        public string subscribe_url_long { get; set; }
        public string beamer_address { get; set; }
        public string visibility { get; set; }
        public List<object> modules { get; set; }
        public Stats stats { get; set; }
        public List<Link> _links { get; set; }
    }

    public class Link2
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string method { get; set; }
        public string targetSchema { get; set; }
        public string schema { get; set; }
    }

    public class AllLists
    {
        public List<List> lists { get; set; }
        public List<Link2> _links { get; set; }
        public int total_items { get; set; }
    }
    #endregion
}