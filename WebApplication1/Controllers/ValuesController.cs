using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class kitT
    {
        public double perc { get; set; }
        public string kitstate { get; set; }
        public DateTime lastupdated { get; set; }
        public int countoffiles { get; set; }
        public string kit { get; set; }
    }

    public class kitsT
    {
        public kitT[] kits { get; set; }
    }
    public class kitscompletedpercController : ApiController
    {
        // GET api/values
        [HttpGet]
        public kitsT Get()
        {
            kitsT kitsT = new kitsT();
            int n = 10;
            List<kitT> kts = new List<kitT>();
            for (int i = 0; i < n; i++)
            {
                kitT k = new kitT();
                k.perc = new Random(DateTime.Now.Millisecond + 100 * i).Next(new Random(DateTime.Now.Millisecond).Next(100));
                string s = new Random(DateTime.Now.Millisecond + 100 * i).Next(new Random(DateTime.Now.Millisecond).Next(100)).ToString();
                k.kit = "Kit" + s;
                k.kitstate = "In Progress";
                k.lastupdated = DateTime.Now;
                k.countoffiles = new Random(DateTime.Now.Millisecond + 100 * i).Next(new Random(DateTime.Now.Millisecond).Next(100));
                kts.Add(k);
            }
            kitsT.kits = kts.ToArray();
            return kitsT;
        }
    }

    public class failedfile
    {
        public string kitname { get; set; }
        public string destination { get; set; }
        public DateTime lastupdated { get; set; }
        public  string filename { get; set; }
    }

    public class failedfilesT
    {
        public failedfile[] failedfiles { get; set; }
    }


    public class FailedFilesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public failedfilesT Get()
        {
            failedfilesT failedfiles = new failedfilesT();
            int n = 10;
            List<failedfile> fs = new List<failedfile>();
            for (int i = 0; i < n; i++)
            {
                failedfile f = new failedfile();
                f.destination = "Snowball11_Dest"+ i.ToString();
                f.filename = string.Format(@"E:\KitSource\KIT_22\subfolder\SendMail{0}.py", i);
                string s = new Random(DateTime.Now.Millisecond + 100 * i).Next(new Random(DateTime.Now.Millisecond).Next(100)).ToString();
                f.kitname = @"KIT" + s;
                f.lastupdated = DateTime.Now;
                fs.Add(f);
            }
            failedfiles.failedfiles = fs.ToArray();

            return failedfiles;
        }
    }



    public class SnowBallFreeSpacePercController : ApiController
    {
        // POST api/values
        public class snowBall
        {
            public double perc { get; set; }
            public string sbstate { get; set; }
            public string snowball { get; set; }
            public DateTime lastupdated { get; set; }
            public int remperc { get; set; }
        }
        public class snowBallsT
        {
            public snowBall[] snowBalls
            {
                get
                {
                    int n = 2;
                   

                    List<snowBall> sbls = new List<snowBall>();
                    for (int i = 0; i < n; i++)
                    {
                        snowBall ball = new snowBall();
                        ball.lastupdated = DateTime.Now;
                        ball.perc = new Random(DateTime.Now.Millisecond + 100 * i).Next(new Random(DateTime.Now.Millisecond).Next(100));
                        ball.sbstate = "Active";
                        ball.snowball = "Snowball" + i.ToString();

                        ball.remperc = new Random(DateTime.Now.Second + DateTime.Now.Millisecond).Next(new Random(DateTime.Now.Second).Next(500));
                        sbls.Add(ball);
                    }
                    return sbls.ToArray();
                }
            }

        }



        [HttpGet]
        public snowBallsT Get()
        {
            snowBallsT t = new snowBallsT();
            var r = JsonConvert.SerializeObject(t);
            return t;
        }

    }


    public class Description
    {
        public string Message { get; set; }
        public string rabbitMQurl { get; set; }
        public string Token { get; set; }
        public string User { get; set; }
    }


    public class LoginData
    {
        public string InternalErrorDesc { get; set; }
        public int ResultCode { get; set; }
        public Description Description = new Description();
        public string Detail { get; set; }
    }

    public class loginController : ApiController
    {
        // POST api/values
        [HttpPost]
        public LoginData Post([FromBody]dynamic value)
        {

            LoginData d = new LoginData();
            d.InternalErrorDesc = "";
            d.ResultCode = 0;
            d.Description.Message = "logged-in successfully";
            d.Description.rabbitMQurl = "http://localhost:15672/#/queues";
            d.Description.Token = "baef63887a8c590316149c34d4effc8c";
            d.Description.User = value.username;
            d.Detail = "";


            var r = JsonConvert.SerializeObject(d);
            return d;
        }
    }




    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
