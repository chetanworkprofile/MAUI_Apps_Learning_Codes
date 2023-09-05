package crc64c1fa7908fd2485d8;


public class DangerousTrustProvider
	extends java.security.Provider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyApp.Platforms.Android.DangerousTrustProvider, PartsClient", DangerousTrustProvider.class, __md_methods);
	}


	public DangerousTrustProvider (java.lang.String p0, double p1, java.lang.String p2)
	{
		super (p0, p1, p2);
		if (getClass () == DangerousTrustProvider.class)
			mono.android.TypeManager.Activate ("MyApp.Platforms.Android.DangerousTrustProvider, PartsClient", "System.String, System.Private.CoreLib:System.Double, System.Private.CoreLib:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
