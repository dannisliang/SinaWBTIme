using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Weibo;
using NetDimension.Web;
using System.Data;
using System.Configuration;
using System.Text;



public partial class me : System.Web.UI.Page
{
    Cookie cookie = new Cookie("WeiboDemo", 24, TimeUnit.Hour);

    Client Sina = null;
    string UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(cookie["AccessToken"]))
        {
            Response.RedirectPermanent("Login.aspx");
        }
        else
        {
            Sina = new Client(new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], cookie["AccessToken"], null)); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
        }

        UserID = Sina.API.Entity.Account.GetUID();

        BindData();
       
    }
   
    #region 获取数据集
    private List<SelfWeiBo> GetSelfWeiBo()
    {
        List<SelfWeiBo> SelfWeiBos = new List<SelfWeiBo>();
        var json = Sina.API.Dynamic.Statuses.UserTimeline("","","","",100,1,false,0,false);//此处新浪对于普通开发者有限制，只能返回数据的前100条，第一页
        foreach (var status in json.statuses)
        {
            SelfWeiBo ds = new SelfWeiBo
            {
                SendTime = status.created_at,
                Content = status.text,

            };

            SelfWeiBos.Add(ds);
        }
        return SelfWeiBos;
    }//在新浪微博抓取数据并在此方法中解析
    #endregion 获取数据集
    public void BindData()
    {
        List<int> years = new List<int>();
        //years.Add(2013);
        List<SelfWeiBo> selfs = GetSelfWeiBo();
        for (int i = 0; i < selfs.Count; i++)
        {
            int a = Convert.ToInt32(selfs[i].SendTime.Substring(26));
            int b = 0;
            for (int j = 0; j < years.Count; j++)
            {

                if (a == years[j])
                {
                    b++;
                }

            }
            if (b == 0)
            {
                years.Add(a);
            }
            else
            {
                b = 0;
            }
        }

        DataSet ds = new DataSet();
        DataTable dt = new DataTable("AllYear");
        dt.Columns.Add("Year");
        for (int k = 0; k < years.Count; k++)
        {
            DataRow dr = dt.NewRow();
            dr["Year"] = years[k].ToString();
            dt.Rows.Add(dr);
        }
        ds.Tables.Add(dt);
        rptAll.DataSource = ds;
        rptAll.DataBind();
    }

    #region 外层Repeater数据响应事件
    protected void rptAll_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //我们先通过rptAll来找到 rptA
            Repeater rptA = e.Item.FindControl("rptA") as Repeater;
            HiddenField year = e.Item.FindControl("year") as HiddenField;

            string yy = year.Value.ToString();
            List<SelfWeiBo> haha = GetSelfWeiBo();
            List<SelfWeiBo> ress = new List<SelfWeiBo>();
            for (int m = 0; m < haha.Count; m++)
            {
                if (haha[m].SendTime.Substring(26).ToString() == yy)
                {
                    ress.Add(haha[m]);
                }
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Sina");
            dt.Columns.Add("SendTime");
            dt.Columns.Add("YearYear");
            dt.Columns.Add("Content");
            for (int n = 0; n < ress.Count; n++)
            {
                DataRow dr = dt.NewRow();
               // dr["SendTime"] = ress[n].SendTime;
                string intitime = ress[n].SendTime;
                switch (intitime.Substring(4,3))
                { 
                    case "Jan":
                        dr["SendTime"]="01."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                    case "Feb":
                        dr["SendTime"]="02."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                    case "Mar":
                        dr["SendTime"]="03."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                     case "Apr":
                        dr["SendTime"]="04."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                    case "May":
                        dr["SendTime"]="05."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                     case "Jun":
                        dr["SendTime"]="06."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                     case "Jul":
                        dr["SendTime"]="07."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                      case "Aug":
                        dr["SendTime"]="08."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                      case "Sep":
                        dr["SendTime"]="09."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                      case "Oct":
                        dr["SendTime"]="10."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                      case "Nov":
                        dr["SendTime"]="11."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;
                      case "Dec":
                        dr["SendTime"]="12."+intitime.Substring(8,2);
                        dr["YearYear"]=intitime.Substring(26);
                        break;


                }
                dr["Content"] = ress[n].Content.Length > 20 ?ress[n].Content.Substring(0,20)+"...More":ress[n].Content;
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            rptA.DataSource = ds;
            rptA.DataBind();

        }
    #endregion 外层Repeater数据响应事件

    }
}