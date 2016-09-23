package md5430eef72268cc48c2c6422a446db3170;


public class Cardapio
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ClienteAndroid.Cardapio, ClienteAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Cardapio.class, __md_methods);
	}


	public Cardapio () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Cardapio.class)
			mono.android.TypeManager.Activate ("ClienteAndroid.Cardapio, ClienteAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
