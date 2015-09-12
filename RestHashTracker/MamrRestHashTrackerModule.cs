using System;
using System.Web;
using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.WebServices;
using CMS.Base;
using CMS.UIControls;
using MAMR.RestHashTracker;

[assembly: RegisterModule(typeof(MamrRestHashTrackerModule))]
public class MamrRestHashTrackerModule : Module
{
    /// <summary>
    /// Constructor for module
    /// </summary>
    public MamrRestHashTrackerModule() : base("MamrRestHashTrackerModule"){}

    /// <summary>
    /// Initializes the module. Called when the application starts.
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        HashInfo.TYPEINFO.Events.Insert.Before += HashGenerateSecureUrl;
        HashInfo.TYPEINFO.Events.Update.Before += HashGenerateSecureUrl;
        UniGridTransformations.Global.RegisterTransformation("#getresthashtrackerlink", GetRestHashTrackerLink);
        UniGridTransformations.Global.RegisterTransformation("#getresthashtrackertype", GetRestHashTrackerType);
    }

    /// <summary>
    /// Generate the secure URL (original URL with hash)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HashGenerateSecureUrl(object sender, ObjectEventArgs e)
    {
        var url = e.Object.GetStringValue("HashUrl", string.Empty);
        var hashSecureUrl = "";

        string urlWithoutHash = URLHelper.RemoveParameterFromUrl(url, "hash");
        string newUrl = HttpUtility.UrlDecode(urlWithoutHash);
        string query = URLHelper.GetQuery(newUrl).TrimStart('?');

        int index = newUrl.IndexOfCSafe("/rest", true);
        if (index >= 0)
        {
            string domain = URLHelper.GetDomain(newUrl);
            newUrl = URLHelper.RemoveQuery(newUrl.Substring(index));

            string[] rewritten = BaseRESTService.RewriteRESTUrl(newUrl, query, domain, "GET");
            newUrl = rewritten[0].TrimStart('~') + "?" + rewritten[1];

            hashSecureUrl += URLHelper.AddParameterToUrl(urlWithoutHash, "hash", RESTService.GetHashForURL(newUrl, domain)) + Environment.NewLine;
            e.Object.SetValue("HashSecureUrl", hashSecureUrl);
        }
    }

    private static object GetRestHashTrackerLink(object parameter)
    {
        var link = ValidationHelper.GetString(parameter, string.Empty);
        return string.Format("<a href=\"{0}\" target=\"_blank\">Open</a>", link, link);
    }

    private static object GetRestHashTrackerType(object parameter)
    {
        var link = ValidationHelper.GetString(parameter, string.Empty);

        if (link.ToLower().Contains("format=json"))
        {
            return "JSON";
        }

        return "XML";
    }
}
