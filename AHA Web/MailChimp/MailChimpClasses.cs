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
    public class NewMember
    {
        public string email_address { get; set; }
        public string status { get; set; }
        public MergeFields merge_fields { get; set; }
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