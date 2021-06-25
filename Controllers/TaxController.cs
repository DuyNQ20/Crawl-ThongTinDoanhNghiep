using APICrawlDataThongTinDoanhNghiep.Data;
using APICrawlDataThongTinDoanhNghiep.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APICrawlDataThongTinDoanhNghiep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private DataContext _dataContext;
        public TaxController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("url")]
        public IActionResult GetUrl()
        {
            var cityUri = ExtensionMethod.GetCityUris();
            var urls = ExtensionMethod.GetStartUrl(null, cityUri);
            return Ok(urls);
        }
        public IActionResult Get()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var cityUri = ExtensionMethod.GetCityUris();
            var startUrls = ExtensionMethod.GetStartUrl(null, cityUri);
            int pageSize = 100;
            Console.WriteLine("=========== BAT DAU ===========");
           
            foreach (var url in startUrls)
            {
                Console.WriteLine("URL: " + url.Key);
                Console.WriteLine("Tong so: " + url.Value);
                var watch2 = System.Diagnostics.Stopwatch.StartNew();
                int totalPage = (int)Math.Ceiling((double)url.Value / pageSize);
                bool check = false;
               
                for (int i = 1; i <= totalPage; i++)
                {
                    var pageUrl = url.Key + "&p=" + i;
                    var data = ExtensionMethod.Crawl(pageUrl, pageSize);
                    try
                    {
                        var listTemp = data.LtsItems.GroupBy(x => x.MaSoThue);
                        var taxs = new List<Tax>();
                        foreach (var item in listTemp)
                        {
                            var it = item.First();
                            var checkExist = _dataContext.Taxs.Find(it.MaSoThue);
                            if (checkExist == null)
                            {
                                taxs.Add(it);
                            }
                        }

                        if (taxs.Count > 0)
                        {
                            _dataContext.Taxs.AddRange(taxs);
                            _dataContext.Options.Add(data.Option);
                            _dataContext.Roots.Add(data);
                            _dataContext.LtsMaps.AddRange(data.LtsMaps);
                            _dataContext.SaveChanges();
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                        //break;
                    };
                }


                

                if (check) 

                watch2.Stop();
                Console.WriteLine("Tong thoi gian: " + watch2.ElapsedMilliseconds);
            }

            watch.Stop();
            Console.WriteLine("=========== KET THUC ===========");
            Console.WriteLine($"Tong thoi gian thuc hien: {watch.ElapsedMilliseconds} ms");
            return Ok("okok");
        }
    }

    public static class ExtensionMethod{
        public static Root Crawl(string url, int pageSize)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(url + "&r=" + pageSize));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var items = JsonConvert.DeserializeObject<Root>(jsonString);

            return items;
        }

        public static List<string> GetCityUris()
        {
            return new List<string>(new string[] {
            "an-giang",
            "bac-can",
            "bac-giang",
            "bac-lieu",
            "bac-ninh",
            "ben-tre",
            "binh-dinh",
            "binh-duong",
            "binh-phuoc",
            "binh-thuan",
            "ca-mau",
            "can-tho",
            "cao-bang",
            "chua-ro",
            "da-nang",
            "dac-lac",
            "dak-nong",
            "dien-bien",
            "dong-nai",
            "dong-thap",
            "gia-lai",
            "ha-giang",
            "ha-nam",
            "ha-noi",
            "ha-tinh",
            "hai-duong",
            "hai-phong",
            "hau-giang",
            "hoa-binh",
            "hue",
            "hung-yen",
            "khanh-hoa",
            "kien-giang",
            "kon-tum",
            "lai-chau",
            "lam-dong",
            "lang-son",
            "lao-cai",
            "long-an",
            "nam-dinh",
            "nghe-an",
            "ninh-binh",
            "ninh-thuan",
            "phu-tho",
            "phu-yen",
            "quang-binh",
            "quang-nam",
            "quang-ngai",
            "quang-ninh",
            "quang-tri",
            "soc-trang",
            "son-la",
            "tay-ninh",
            "thai-binh",
            "thai-nguyen",
            "thanh-hoa",
            "tien-giang",
            "tp-ho-chi-minh",
            "tra-vinh",
            "tuyen-quang",
            "vinh-long",
            "vinh-phuc",
            "vung-tau",
            "yen-bai",
            });
        }

        public static Dictionary<string, int> GetStartUrl(Dictionary<string, int> urls, List<string> cityUris)
        {
            if (urls == null || urls.Count == 0) urls = new Dictionary<string, int>();
            //var urls = new List<string>();
            var root = "https://thongtindoanhnghiep.co/api/company";

            //var cityUris = GetCityUris();

            foreach (var uri in cityUris)
            {
                var url = root + "?l=" + uri;
                var data = Crawl(url, 1);
                if(data.Option.TotalRow < 100000)
                {
                    urls.Add(url, data.Option.TotalRow);
                }
                else
                {
                    var links = new List<string>();
                    foreach (var item in data.LtsFacets)
                    {
                        links.Add(item.UrlFacet);
                    }
                    GetStartUrl(urls, links);
                }
            }

            return urls;
        }
    }
}
