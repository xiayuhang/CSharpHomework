using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace homework9
{
    class Program
    {
        public class Crawler
        {
            private WebClient webClient = new WebClient();
            private Hashtable urls = Hashtable.Synchronized(new Hashtable());  //保证urls是线程安全的
            private static int count = 0;  //并行爬取时，count设置为静态变量
            private string startUrl;  //记录开始时的URL

            static void Main(string[] args)
            {
                Crawler myCrawler = new Crawler();

                string startUrl = "https://www.csdn.net/";
                myCrawler.startUrl = startUrl;
                if (args.Length >= 1)
                    startUrl = args[0];

                myCrawler.urls.Add(startUrl, false);

                myCrawler.Crawl();
            }

            private void Crawl()
            {
                Console.WriteLine("开始爬行了....");
                if (count == 0)
                {
                    string html = DownLoad(startUrl);
                    Parse(html);
                }
                Parallel.For(1, 3, i => CrawlMethod(i));  //两个线程并行爬取
                Console.WriteLine("爬行结束");
            }

            public void CrawlMethod(int index)
            {
                while (true)
                {
                    string html = null;
                    string current = null;
                    lock (this)  //给爬取代码块上锁，防止多个线程爬取同一URL
                    {
                        foreach (string url in urls.Keys)
                        {
                            if ((bool)urls[url]) continue;
                            current = url;
                        }
                        if (current == null || count > 10)
                            break;

                        Console.WriteLine("线程" + index + " 爬行" + current + "页面！");

                        html = DownLoad(current); //下载

                        urls[current] = true;
                        count++;
                    }
                    Parse(html);   //加入新链接时不必上锁
                }
            }

            public string DownLoad(string url)
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                    byte[] buffer = ReadInStream2Memory(response.GetResponseStream());
                    string fileName = @"..\..\" + count.ToString();
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                    string html = Encoding.UTF8.GetString(buffer);
                    return html;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "";
                }
            }

            public void Parse(string html)
            {
                string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                    if (strRef.Length == 0)
                        continue;
                    if (urls[strRef] == null)
                        urls[strRef] = false;
                }
            }

            private static byte[] ReadInStream2Memory(Stream responseStream)
            {
                int bufferSize = 16384;
                byte[] buffer = new byte[bufferSize];
                MemoryStream ms = new MemoryStream();
                while (true)
                {
                    int numBytesRead = responseStream.Read(buffer, 0, bufferSize);
                    if (numBytesRead <= 0)
                        break;
                    ms.Write(buffer, 0, numBytesRead);
                }
                return ms.ToArray();
            }
        }
    }
}
