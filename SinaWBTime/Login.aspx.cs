using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Web;//这个命名空间的代码在App_Code里面，不要再跑了群里找我要了哈
using NetDimension.Weibo;
using System.Configuration;
using System.Text;


public partial class Login : System.Web.UI.Page
{
    Cookie cookie = new Cookie("WeiboDemo", 24, TimeUnit.Hour);

    Client Sina = null;
    OAuth oauth = new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], ConfigurationManager.AppSettings["CallbackUrl"]);

    protected void Page_Load(object sender, EventArgs e)
    {

        Sina = new Client(oauth); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
        if (!IsPostBack)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                var token = oauth.GetAccessTokenByAuthorizationCode(Request.QueryString["code"]);
                string accessToken = token.Token;

                cookie["AccessToken"] = accessToken;

                Response.Redirect("http://127.0.0.1/SinaTime.aspx");
            }
            else
            {
                string url = oauth.GetAuthorizeURL();
                authUrl.NavigateUrl = url;
            }

        }

    }
}