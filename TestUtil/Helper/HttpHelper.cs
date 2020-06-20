using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestUtil.Helper
{
    public class HttpHelper
    {
        public static Response Post(string url,string data)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsPost = true;
            httpRequestModel.Data = data;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return AskData(httpRequestModel);
        }
        public static Response Get(string url)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsGet = true;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return AskData(httpRequestModel);
        }
        /// <summary>
        /// 基础httprequest方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Response AskData(HttpRequestModel model)
        {
            Response _Response = new Response();
            _Response.ErrCode = 0;
            _Response.ErrMsg = "成功";

            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler()))
                {
                    //client.GetHostConfiguration().setProxy("192.168.101.1", 5608);

                    client.BaseAddress = new Uri(model.Url);
                    if (model.OutTime > 0)
                    {
                        client.Timeout = new TimeSpan(0, 0, 0, 0, model.OutTime * 1000);
                    }
                    else
                    {
                        client.Timeout = new TimeSpan(0, 0, 0, 0, 30000);
                    }

                    MediaTypeHeaderValue typeHeader = null;


                    #region 添加头信息
                    if (model.DicHeaders != null && model.DicHeaders.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> item in model.DicHeaders)
                        {
                            //添加头信息
                            if (item.Key != null && item.Value != null)
                            {
                                if (item.Key == "Content-Type")
                                {
                                    if (item.Value == "application/json;charset=utf-8")
                                    {
                                        typeHeader = new MediaTypeHeaderValue("application/json");
                                        typeHeader.CharSet = "utf-8";
                                    }
                                    else if (item.Value == "application/x-www-form-urlencoded; charset=UTF-8")
                                    {
                                        typeHeader = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                                        typeHeader.CharSet = "UTF-8";
                                    }
                                    else
                                    {
                                        if (item.Value.Contains(";"))
                                        {
                                            var temp = item.Value.Split(';');
                                            typeHeader = new MediaTypeHeaderValue(temp[0]);
                                            typeHeader.CharSet = temp[1].Split('=')[1];
                                        }
                                        else
                                        {
                                            typeHeader = new MediaTypeHeaderValue(item.Value);
                                        }
                                    }
                                }
                                else if (item.Key != "Content-Length")
                                {
                                    try
                                    {
                                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region HttpContent
                    HttpContent content = null;
                    if (model.IsPost && model.Data != null)
                    {
                        if (model.Data is string)
                        {
                            content = new StringContent(model.Data as string);
                        }
                        else
                        {
                            content = new StringContent(JsonConvert.SerializeObject(model.Data));
                        }

                        if (typeHeader == null)
                        {
                            typeHeader = new MediaTypeHeaderValue("application/json");
                        }

                        if (typeHeader.CharSet == null)
                        {
                            typeHeader.CharSet = "UTF-8";
                        }

                        content.Headers.ContentType = typeHeader;
                    }
                    #endregion

                    Task<HttpResponseMessage> _taskResponse = model.IsPost ? client.PostAsync(model.Url, content) : client.GetAsync(model.Url);

                    #region 等待异步执行完毕

                    while (_taskResponse.IsCompleted == false)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    //检查请求完成后的状态
                    if (_taskResponse.IsCompleted)
                    {
                        if (_taskResponse.IsCanceled)
                        {
                            _Response.ErrCode = 4;
                            _Response.ErrMsg = "请求超时";
                            _Response.LogInfo = _Response.ErrMsg;
                        }
                        else if (_taskResponse.IsFaulted)
                        {
                            _Response.ErrCode = 3;
                            _Response.ErrMsg = "无法连接到目标地址";
                            _Response.LogInfo = _Response.ErrMsg;
                        }
                    }
                    #endregion

                    HttpResponseMessage response = null;

                    //成功执行请求
                    if (_taskResponse.Status == TaskStatus.RanToCompletion)
                    {
                        response = _taskResponse.Result;
                        _Response.HttpResponseMessage = response;

                        _Response.Result = _Response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                    }
                    if (response != null && !response.IsSuccessStatusCode)
                    {
                        _Response.ErrCode = (int)response.StatusCode;
                        _Response.ErrMsg = response.StatusCode.ToString();
                    }
                    else if (response != null && response.IsSuccessStatusCode)
                    {
                        _Response.ErrCode = 0;
                        _Response.ErrMsg = "成功";

                    }
                }


            }
            catch (Exception ex)
            {
                _Response.ErrCode = 6;
                _Response.ErrMsg = "网络请求发生异常:" + ex.Message;

            }
            return _Response;
        }
        public static Response PostInstance(string url, string data)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsPost = true;
            httpRequestModel.Data = data;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return AskDataInstance(httpRequestModel);
        }
        public static Response GetInstance(string url)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsGet = true;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return AskDataInstance(httpRequestModel);
        }
        public static Dictionary<string,HttpClient> clients = new Dictionary<string, HttpClient>();//new HttpClient(new HttpClientHandler());
        public static HttpClient httpClient = new HttpClient(new HttpClientHandler());
        /// <summary>
        /// 基础httprequest方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Response AskDataInstance(HttpRequestModel model)
        {
            Response _Response = new Response();
            _Response.ErrCode = 0;
            _Response.ErrMsg = "成功";

            try
            {
                //client.GetHostConfiguration().setProxy("192.168.101.1", 5608);
                //HttpClient httpClient;
                //if (clients.ContainsKey((model.Url)))
                //{
                //    httpClient = clients[model.Url];
                //}
                //else
                //{
                //    httpClient = new HttpClient(new HttpClientHandler());
                //    httpClient.BaseAddress = new Uri("https://618.tmall.com/");
                //    if (model.OutTime > 0)
                //    {
                //        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, model.OutTime * 1000);
                //    }
                //    else
                //    {
                //        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 30000);
                //    }
                //    httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                //    clients.Add(model.Url,httpClient);
                //}
                //if (model.OutTime > 0)
                //{
                //    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, model.OutTime * 1000);
                //}
                //else
                //{
                //    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 30000);
                //}
                httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                MediaTypeHeaderValue typeHeader = null;

                #region 添加头信息
                if (model.DicHeaders != null && model.DicHeaders.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in model.DicHeaders)
                    {
                        //添加头信息
                        if (item.Key != null && item.Value != null)
                        {
                            if (item.Key == "Content-Type")
                            {
                                if (item.Value == "application/json;charset=utf-8")
                                {
                                    typeHeader = new MediaTypeHeaderValue("application/json");
                                    typeHeader.CharSet = "utf-8";
                                }
                                else if (item.Value == "application/x-www-form-urlencoded; charset=UTF-8")
                                {
                                    typeHeader = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                                    typeHeader.CharSet = "UTF-8";
                                }
                                else
                                {
                                    if (item.Value.Contains(";"))
                                    {
                                        var temp = item.Value.Split(';');
                                        typeHeader = new MediaTypeHeaderValue(temp[0]);
                                        typeHeader.CharSet = temp[1].Split('=')[1];
                                    }
                                    else
                                    {
                                        typeHeader = new MediaTypeHeaderValue(item.Value);
                                    }
                                }
                            }
                            else if (item.Key != "Content-Length")
                            {
                                try
                                {
                                    httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                                }
                                catch (Exception ee)
                                {

                                }
                            }
                        }
                    }
                }
                #endregion

                #region HttpContent
                HttpContent content = null;
                if (model.IsPost && model.Data != null)
                {
                    if (model.Data is string)
                    {
                        content = new StringContent(model.Data as string);
                    }
                    else
                    {
                        content = new StringContent(JsonConvert.SerializeObject(model.Data));
                    }

                    if (typeHeader == null)
                    {
                        typeHeader = new MediaTypeHeaderValue("application/json");
                    }

                    if (typeHeader.CharSet == null)
                    {
                        typeHeader.CharSet = "UTF-8";
                    }

                    content.Headers.ContentType = typeHeader;
                }
                #endregion

                Task<HttpResponseMessage> _taskResponse = model.IsPost ? httpClient.PostAsync(model.Url, content) : httpClient.GetAsync(model.Url);

                #region 等待异步执行完毕
                while (_taskResponse.IsCompleted == false)
                {
                    System.Threading.Thread.Sleep(50);
                }

                //检查请求完成后的状态
                if (_taskResponse.IsCompleted)
                {
                    if (_taskResponse.IsCanceled)
                    {
                        _Response.ErrCode = 4;
                        _Response.ErrMsg = "请求超时";
                        _Response.LogInfo = _Response.ErrMsg;
                    }
                    else if (_taskResponse.IsFaulted)
                    {
                        _Response.ErrCode = 3;
                        _Response.ErrMsg = "无法连接到目标地址";
                        _Response.LogInfo = _Response.ErrMsg;
                    }
                }
                #endregion

                HttpResponseMessage response = null;

                //成功执行请求
                if (_taskResponse.Status == TaskStatus.RanToCompletion)
                {
                    response = _taskResponse.Result;
                    _Response.HttpResponseMessage = response;

                    _Response.Result = _Response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                }
                if (response != null && !response.IsSuccessStatusCode)
                {
                    _Response.ErrCode = (int)response.StatusCode;
                    _Response.ErrMsg = response.StatusCode.ToString();
                }
                else if (response != null && response.IsSuccessStatusCode)
                {
                    _Response.ErrCode = 0;
                    _Response.ErrMsg = "成功";

                }


            }
            catch (Exception ex)
            {
                _Response.ErrCode = 6;
                _Response.ErrMsg = "网络请求发生异常:" + ex.Message;

            }
            return _Response;
        }
    }
    public class HttpRequestModel
    {
        /// <summary>
        /// 请求类型 0Post 1Get
        /// </summary>
        public int RequestType { get; set; }

        public bool IsPost
        {
            get
            {
                return RequestType == 0;
            }
            set
            {
                if (value == true) RequestType = 0;
                else RequestType = 1;
            }
        }
        public bool IsGet
        {
            get
            {
                return RequestType == 1;
            }
            set
            {
                if (value == true) RequestType = 1;
                else RequestType = 0;
            }
        }
        /// <summary>
        /// 税友专用字段
        /// </summary>
        public Dictionary<string, string> ParamDic_ShuiYou { get; set; }
        /// <summary>
        /// 请求数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 请求的URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Cookie
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// 头信息
        /// </summary>
        public Dictionary<string, string> DicHeaders { get; set; }
        /// <summary>
        /// 超时时间(秒)
        /// </summary>
        public int OutTime { get; set; }
        /// <summary>
        /// 请求Key
        /// </summary>
        public string RequestKey { get; set; }

    }
    public class Response
    {
        /// <summary>
        /// 返回的结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 返回的日志信息
        /// </summary>
        public string LogInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccess { get; set; }
        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
