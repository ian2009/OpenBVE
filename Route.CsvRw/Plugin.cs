using System;
using System.Text;
using OpenBveApi.FileSystem;
using OpenBveApi.Hosts;
using OpenBveApi.Routes;
using RouteManager2;

namespace Plugin
{
    public class Plugin : RouteInterface
    {
	    internal static HostInterface currentHost;

	    internal static bool EnableBveTsHacks;

	    internal static CurrentRoute CurrentRoute;

	    internal static FileSystem FileSystem;

		internal static Random RandomNumberGenerator = new Random();

	    public override void Load(HostInterface host, FileSystem fileSystem)
	    {
		    currentHost = host;
	    }

	    public override bool CanLoadRoute(string path)
	    {
		    path = path.ToLowerInvariant();
		    if (path.EndsWith(".csv") || path.EndsWith(".rw"))
		    {
			    return true;
		    }
			return false;
	    }

	    public override bool LoadRoute(string path, Encoding Encoding, out object Route)
	    {
		    Route = CurrentRoute;
		    return true;
	    }
    }
}
