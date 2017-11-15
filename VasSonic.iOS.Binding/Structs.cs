using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace VasSonic.iOS
{
	[Native]
	public enum SonicStatusCode : ulong
	{
		AllCached = 304,
		TemplateUpdate = 2000,
		FirstLoad = 1000,
		DataUpdate = 200
	}

	[Native]
	public enum SonicURLProtocolAction : ulong
	{
		LoadData,
		RecvResponse,
		DidSuccess,
		DidFaild
	}

	[Native]
	public enum SonicErrorType : long
	{
		Ioe = -901,
		Toe = -902,
		HtmlVerifyFail = -1001,
		MakeDirError = -1003,
		WriteFileFail = -1004,
		SplitHtmlFail = -1005,
		MergeDiffDataFail = -1006,
		ServerDataException = -1007,
		BuildHtmlError = -1008,
		UrlprotocolError = -1009
	}
	 
	        
	public static class CFunctions
	{
		public delegate void NSDispatchHandlerT();
		// extern NSString * dispatchToSonicSessionQueue (dispatch_block_t block);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		public static extern NSString dispatchToSonicSessionQueue (NSDispatchHandlerT block);

		// extern NSString * sonicSessionID (NSString *url);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		public static extern NSString sonicSessionID (NSString url);

		// extern NSString * dispatchToMain (dispatch_block_t block);
		[DllImport ("__Internal")]
		////[Verify (PlatformInvoke)]
		public static extern NSString dispatchToMain (NSDispatchHandlerT block);

		// extern NSString * getDataSha1 (NSData *data);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		public static extern NSString getDataSha1 (NSData data);
	}
}
