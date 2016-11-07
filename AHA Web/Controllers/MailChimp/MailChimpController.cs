using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHA_Web.MailChimp;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace AHA_Web.Controllers.MailChimp
{
    public class MailChimpController : Controller
    {
        MailChimp mc = new MailChimp();

        // GET: MailChimp
        public ActionResult Index()
        {
            List<List> allLists = mc.getAllLists().lists;
            ViewBag.lists = allLists;

            return View();
        }

        public ActionResult List(string listID)
        {
            if (listID == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Members members = mc.getListMembers(listID);
            if (members == null)
                return HttpNotFound();
            ViewBag.members = members.members;

            return View();
        }

        public ActionResult AddMember(string listID)
        {
            ViewBag.listID = listID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(NewMember model)
        {
            //var newMember = new NewMember()
            //{
            //    status = "subscribed",
            //    email_address = email,
            //    merge_fields = new MergeFields() { FNAME = fName, LNAME = lName}
            //};
            model.status = "subscribed";
            mc.addListMember("9ce0738c51", model);
            return View(model);
        }
    }

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

        private void SetBasicAuthHeader(WebRequest request)
        {
            string authInfo = username + ":" + apiKey;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }

        private string getWebResponseJson(string url)
        {
            var request = WebRequest.Create(url);
            SetBasicAuthHeader(request);

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

        public void addListMember(string listID, NewMember member)
        {
            var request = WebRequest.Create(baseUri + "/lists/" + listID + "/members");
            SetBasicAuthHeader(request);
            request.Method = "POST";

            //NewMember member = new NewMember();
            //member.email_address = email;
            //member.status = "subscribed";
            //member.merge_fields.FNAME = fName;
            //member.merge_fields.LNAME = lName;

            string postData = JSS.Serialize(member); //String.Format("{\"email_address\":");
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            request.ContentType = "application/json";

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var response = request.GetResponse();
            //Get response properties
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

        }
    }
}