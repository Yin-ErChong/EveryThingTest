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
    public class HttpHelperNew
    {
        public static Dictionary<string, HttpClient> clientDic = new Dictionary<string, HttpClient>();
        public static async Task<Response> PostAsync(string url, string data)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsPost = true;
            httpRequestModel.Data = data;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return await AskDataAsync(httpRequestModel);
        }
        public static async Task<Response> GetAsync(string url)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsGet = true;
            httpRequestModel.Url = url;
            httpRequestModel.OutTime = 20;
            return await AskDataAsync(httpRequestModel);
        }
        public static Response Post(string url, string data)
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
        public static async Task<Response> AskDataAsync(HttpRequestModel model)
        {
            Response _Response = new Response();
            _Response.ErrCode = 0;
            _Response.ErrMsg = "失败";

            try
            {
                #region 生成HttpClient对象
                Uri uri = new Uri(model.Url);
                HttpClient httpClient;
                if (clientDic.ContainsKey(uri.Host))
                {
                    httpClient = clientDic[uri.Host];
                }
                else
                {
                    httpClient = new HttpClient(new HttpClientHandler());

                    if (model.OutTime > 0)
                    {
                        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, model.OutTime * 1000);
                    }
                    else
                    {
                        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 30000);
                    }
                    httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                    clientDic.Add(model.Url, httpClient);
                }
                httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                #endregion

                #region 添加头信息
                MediaTypeHeaderValue typeHeader = null;
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
                                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
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

                #region 解析Reponse
                HttpResponseMessage _taskResponse = null;
                if (model.IsPost)
                {
                    _taskResponse = await httpClient.PostAsync(model.Url, content);
                }
                else
                {
                    _taskResponse = await httpClient.GetAsync(model.Url);
                }
                if (_taskResponse != null && !_taskResponse.IsSuccessStatusCode)
                {
                    _Response.ErrCode = (int)_taskResponse.StatusCode;
                    _Response.ErrMsg = _taskResponse.StatusCode.ToString();
                }
                else if (_taskResponse != null && _taskResponse.IsSuccessStatusCode)
                {
                    _Response.ErrCode = 0;
                    _Response.ErrMsg = "成功";
                }
                #endregion

                return _Response;
            }
            catch (Exception ex)
            {
                _Response.ErrCode = 6;
                _Response.ErrMsg = "网络请求发生异常:" + ex.Message;

            }
            return _Response;
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
                Uri uri= new Uri(model.Url);
                HttpClient httpClient;
                if (clientDic.ContainsKey(uri.Host))
                {
                    httpClient = clientDic[uri.Host];
                }
                else
                {
                    httpClient = new HttpClient(new HttpClientHandler());

                    if (model.OutTime > 0)
                    {
                        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, model.OutTime * 1000);
                    }
                    else
                    {
                        httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 30000);
                    }
                    httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                    clientDic.Add(model.Url, httpClient);
                }
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
                                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
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
}
