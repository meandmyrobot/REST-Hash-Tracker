# REST-Hash-Tracker

### The Problem
Kentico allows you to access its native API via hash parameter authentication.  You can create authenticated URLs via **Settings > Integration > REST**.  Unfortunately there is no way to keep track of the authenticated URLs apart from copying and pasting these into some other tool.  For more information on the Kentico REST API and hash authenticated URLs [ check this out](https://docs.kentico.com/display/K82/Authenticating+REST+requests#AuthenticatingRESTrequests-Hashparameterauthentication).

### The Solution
This simple module lets you generate authenticated URLs and will store them for reference.  You can also click on the generated authenticated URL to check out the response data.

#### List View
![List View](http://i.imgur.com/HzKxX00.png "List View")

#### Detail View
![Detail View](http://i.imgur.com/bDWNZ33.png "Detail View")

### Nuget
* The module [lives here](https://www.nuget.org/packages/MAMR.RestHashTracker/)
* It is versioned against the same Kentico version number that it depends on

### Installation
* Open up your Kentico project
* Open up Package Manager Console
* Make sure CMSApp is the project you are about to install to
* Run *PM> Install-Package MAMR.RestHashTracker*
* Login to Kentico Admin
* Go to **Development > Modules**
* Click import module
* Import in MAMR.RestHashTracker_**X.X.XX**.zip

### As Suggested by Kentico...
> Only use hash parameter authentication for loading data that you want to make publicly available. REST requests with hash authentication can be executed by anyone who obtains the URL (for example by intercepting the web request).