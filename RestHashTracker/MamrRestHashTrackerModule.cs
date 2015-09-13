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

        //Events for the HashInfo object.  This is how we handle generating the read only URL on insert and update.
        HashInfo.TYPEINFO.Events.Insert.Before += HashGenerateSecureUrl;
        HashInfo.TYPEINFO.Events.Update.Before += HashGenerateSecureUrl;

        //Couple of custom transformations for the unigrid used in the list view of the REST Hash Tracker module.
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

        var urlWithoutHash = URLHelper.RemoveParameterFromUrl(url, "hash");
        var newUrl = HttpUtility.UrlDecode(urlWithoutHash);
        var query = URLHelper.GetQuery(newUrl).TrimStart('?');

        int index = newUrl.IndexOfCSafe("/rest", true);
        if (index >= 0)
        {
            var domain = URLHelper.GetDomain(newUrl);
            newUrl = URLHelper.RemoveQuery(newUrl.Substring(index));

            var rewritten = BaseRESTService.RewriteRESTUrl(newUrl, query, domain, "GET");
            newUrl = rewritten[0].TrimStart('~') + "?" + rewritten[1];

            hashSecureUrl += URLHelper.AddParameterToUrl(urlWithoutHash, "hash", RESTService.GetHashForURL(newUrl, domain)) + Environment.NewLine;
            e.Object.SetValue("HashSecureUrl", hashSecureUrl);
        }
    }

    /// <summary>
    /// Create HTML link.
    /// </summary>
    /// <param name="parameter">Value from the UniGrid row.</param>
    /// <returns>HTML Link</returns>
    private static object GetRestHashTrackerLink(object parameter)
    {
        var link = ValidationHelper.GetString(parameter, string.Empty);
        return string.Format("<a href=\"{0}\" target=\"_blank\">Open</a>", link, link);
    }

    /// <summary>
    /// Generate a response type label.
    /// </summary>
    /// <param name="parameter">Value from the UniGrid row.</param>
    /// <returns>Label - "JSON" or "XML" (default)</returns>
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
