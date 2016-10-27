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

        private List<string> exclude_fields = new List<string>() {
            "_links", "total_items",
            "lists._links", "lists.stats",
            "members.stats", "members.last_note", "members.location", "members.interests"
        };
        private string excludeString
        {
            get
            {
                string value = "exclude_fields=";
                foreach (string s in exclude_fields)
                    value += s + ",";
                value.Substring(0, value.Length - 1);
                return value;
            }
        }

        JavaScriptSerializer JSS = new JavaScriptSerializer();

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

        public AllLists getAllLists()
        {
            var response = getWebResponseJson(baseUri + "/lists?" + excludeString);

            //Read data from stream
            AllLists lists = JSS.Deserialize<AllLists>(response);

            return lists;
        }

        public Members getListMembers(string listID)
        {
            var response = getWebResponseJson(String.Format("{0}/lists/{1}/members?{2}", baseUri, listID, excludeString));
            Members members = JSS.Deserialize<Members>(response);

            return members;
        }
    }

    #region Lists Classes
    public class AllLists
    {
        public List<List> lists { get; set; }
    }
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
    }
    #endregion
    #region Members Classes
    public class Members
    {
        public IList<Member> members { get; set; }
        public string list_id { get; set; }
        public int total_items { get; set; }
    }
    public class Member
    {
        public string id { get; set; }
        public string email_address { get; set; }
        public string unique_email_id { get; set; }
        public string email_type { get; set; }
        public string status { get; set; }
        public string status_if_new { get; set; }
        public MergeFields merge_fields { get; set; }
        public string ip_signup { get; set; }
        public string timestamp_signup { get; set; }
        public string ip_opt { get; set; }
        public string timestamp_opt { get; set; }
        public int member_rating { get; set; }
        public string last_changed { get; set; }
        public string language { get; set; }
        public bool vip { get; set; }
        public string email_client { get; set; }
        public string list_id { get; set; }
    }
    public class MergeFields
    {
        public string FNAME { get; set; }
        public string LNAME { get; set; }
    }
    #endregion
}