using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpTestTool.Controllers
{
    class HttpClientController
    {
        #region properties
        private int _timeout;
        private string _contentType;
        private string _accept;
        private Dictionary<string, string> _headers;
        private const string HttpRequestLogStart = "HTTP REQUEST:\r\n";
        private const string HttpResponseLogStart = "\r\nHTTP RESPONSE:\r\n";
        #endregion
        #region constructor
        public HttpClientController(int timeout, string contentType, string accept, Dictionary<string, string> header = null)
        {
            this._timeout = timeout;
            this._headers = header;
            this._contentType = contentType;
            this._accept = accept;
        }
        #endregion
        #region methods
        public void AddHttpHeader(string key, string value)
        {
            if (_headers == null)
            {
                _headers = new Dictionary<string, string>();
            }
            _headers.Add(key,value);
        }
        public string GetData(string url)
        {
            return SendRequest(url, null, "GET");
        }
        public string PostData(string url, string request)
        {
            return SendRequest(url, request, "POST");
        }
        public string PutData(string url, string request)
        {
            return SendRequest(url, request, "PUT");
        }
        public string DeleteData(string url, string request)
        {
            return SendRequest(url, request, "DELETE");
        }
        #endregion
        #region send http request
        private string SendRequest(string url, string request, string method)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = method;
            webRequest.ContentType = _contentType;
            webRequest.Accept = _accept;
            //webRequest.KeepAlive = false;
            SetRequestTimeOut(webRequest);
            SetHeaders(webRequest);
            //webRequest.ServicePoint.MaxIdleTime = 1000*5;
            string response = null;
            try
            {
                if (method != "GET")
                {
                    using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(request);
                    }
                }
                Stream responseStream = webRequest.GetResponse().GetResponseStream();
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    response = responseReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Response == null) throw;
                Stream responseStream = e.Response.GetResponseStream();
                if (responseStream == null) throw;
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    response = responseReader.ReadToEnd();
                }
                if (String.IsNullOrEmpty(response)) throw;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                HttpRequestTrace(webRequest, request, response);
                webRequest = null;
            }
            return response;
        }
        private void SetHeaders(HttpWebRequest webRequest)
        {
            if (_headers == null) return; 
            foreach (KeyValuePair<string, string> header in _headers)
            {
                webRequest.Headers.Add(header.Key, header.Value);
            }
        }
        private void SetRequestTimeOut(HttpWebRequest webRequest)
        {
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Timeout = _timeout;
        }
        private void HttpRequestTrace(HttpWebRequest webRequest, string request, string response)
        {
            string requestLog = HttpRequestLogStart + webRequest.RequestUri + "\r\n";
            requestLog = webRequest.Headers.Keys.Cast<string>()
                .Aggregate(requestLog, (current, key) => current + (key + ":" + webRequest.Headers[key] + "\r\n"));
            requestLog += "\r\n" + request + "\r\n";
            string responseLog = HttpResponseLogStart + webRequest.RequestUri + "\r\n";
            try
            {
                responseLog = webRequest.GetResponse().Headers.Keys.Cast<string>()
                                .Aggregate(responseLog, (current, key) => current + (key + ":" + webRequest.GetResponse().Headers[key] + "\r\n"));
            }
            catch(Exception e)
            {
                responseLog += e.Message+"\r\n";
            }
            responseLog += "\r\n" + response + "\r\n";
            //LogUtility.InfoLog(requestLog + responseLog);
        }
        #endregion
    }
}
