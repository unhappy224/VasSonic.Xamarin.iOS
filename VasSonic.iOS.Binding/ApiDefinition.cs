using System;
using Foundation;
using ObjCRuntime;

namespace VasSonic.iOS
{
	public delegate void NSDispatchHandlerT();

	// @interface SonicConfiguration : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicConfiguration
	{
		// @property (assign, nonatomic) unsigned long long cacheOfflineDisableTime;
		[Export("cacheOfflineDisableTime")]
		ulong CacheOfflineDisableTime { get; set; }

		// @property (assign, nonatomic) unsigned long long cacheMaxDirectorySize;
		[Export("cacheMaxDirectorySize")]
		ulong CacheMaxDirectorySize { get; set; }

		// @property (assign, nonatomic) float cacheDirectorySizeWarningPercent;
		[Export("cacheDirectorySizeWarningPercent")]
		float CacheDirectorySizeWarningPercent { get; set; }

		// @property (assign, nonatomic) float cacheDirectorySizeSafePercent;
		[Export("cacheDirectorySizeSafePercent")]
		float CacheDirectorySizeSafePercent { get; set; }

		// @property (assign, nonatomic) NSInteger maxMemroyCacheItemCount;
		[Export("maxMemroyCacheItemCount")]
		nint MaxMemroyCacheItemCount { get; set; }

		// @property (assign, nonatomic) unsigned long long maxUnStrictModeCacheSeconds;
		[Export("maxUnStrictModeCacheSeconds")]
		ulong MaxUnStrictModeCacheSeconds { get; set; }

		// +(SonicConfiguration *)defaultConfiguration;
		[Static]
		[Export("defaultConfiguration")]
		SonicConfiguration DefaultConfiguration { get; }
	}

	// @interface SonicSessionConfiguration : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicSessionConfiguration
	{
		// @property (retain, nonatomic) NSDictionary * customRequestHeaders;
		[Export("customRequestHeaders", ArgumentSemantic.Retain)]
		NSDictionary CustomRequestHeaders { get; set; }

		// @property (retain, nonatomic) NSDictionary * customResponseHeaders;
		[Export("customResponseHeaders", ArgumentSemantic.Retain)]
		NSDictionary CustomResponseHeaders { get; set; }

		// @property (assign, nonatomic) BOOL supportCacheControl;
		[Export("supportCacheControl")]
		bool SupportCacheControl { get; set; }

		// @property (assign, nonatomic) BOOL enableLocalServer;
		[Export("enableLocalServer")]
		bool EnableLocalServer { get; set; }
	}

	// @protocol SonicConnectionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SonicConnectionDelegate
	{
		// @required -(void)connection:(SonicConnection *)connection didReceiveResponse:(NSHTTPURLResponse *)response;
		[Abstract]
		[Export("connection:didReceiveResponse:")]
		void Connection(SonicConnection connection, NSHttpUrlResponse response);

		// @required -(void)connection:(SonicConnection *)connection didReceiveData:(NSData *)data;
		[Abstract]
		[Export("connection:didReceiveData:")]
		void Connection(SonicConnection connection, NSData data);

		// @required -(void)connection:(SonicConnection *)connection didCompleteWithError:(NSError *)error;
		[Abstract]
		[Export("connection:didCompleteWithError:")]
		void Connection(SonicConnection connection, NSError error);

		// @required -(void)connectionDidCompleteWithoutError:(SonicConnection *)connection;
		[Abstract]
		[Export("connectionDidCompleteWithoutError:")]
		void ConnectionDidCompleteWithoutError(SonicConnection connection);
	}

	interface ISonicServerDelegate
	{

	}

	// @protocol SonicServerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SonicServerDelegate
	{
		// @required -(void)server:(SonicServer *)server didRecieveResponse:(NSHTTPURLResponse *)response;
		[Abstract]
		[Export("server:didRecieveResponse:")]
		void Server(SonicServer server, NSHttpUrlResponse response);

		// @required -(void)server:(SonicServer *)server didReceiveData:(NSData *)data;
		[Abstract]
		[Export("server:didReceiveData:")]
		void Server(SonicServer server, NSData data);

		// @required -(void)server:(SonicServer *)server didCompleteWithError:(NSError *)error;
		[Abstract]
		[Export("server:didCompleteWithError:")]
		void Server(SonicServer server, NSError error);

		// @required -(void)serverDidCompleteWithoutError:(SonicServer *)server;
		[Abstract]
		[Export("serverDidCompleteWithoutError:")]
		void ServerDidCompleteWithoutError(SonicServer server);
	}

	// @protocol SonicSessionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SonicSessionDelegate
	{
		// @required -(void)session:(SonicSession *)session requireWebViewReload:(NSURLRequest *)request;
		[Abstract]
		[Export("session:requireWebViewReload:")]
		void Session(SonicSession session, NSUrlRequest request);

		// @optional -(void)sessionWillRequest:(SonicSession *)session;
		[Export("sessionWillRequest:")]
		void SessionWillRequest(SonicSession session);
	}

	// typedef void (^SonicURLProtocolCallBack)(NSDictionary *);
	delegate void SonicURLProtocolCallBack(NSDictionary arg0);

	// typedef void (^SonicWebviewCallBack)(NSDictionary *);
	delegate void SonicWebviewCallBack(NSDictionary arg0);

	// typedef void (^SonicSessionCompleteCallback)(NSString *);
	delegate void SonicSessionCompleteCallback(string arg0);

	// @interface SonicSession : NSObject <SonicServerDelegate>
	[BaseType(typeof(NSObject))]
	interface SonicSession : ISonicServerDelegate
	{
		// @property (assign, nonatomic) BOOL isFirstLoad;
		[Export("isFirstLoad")]
		bool IsFirstLoad { get; set; }

		// @property (copy, nonatomic) NSString * url;
		[Export("url")]
		string Url { get; set; }

		// @property (readonly, nonatomic) NSString * sessionID;
		[Export("sessionID")]
		string SessionID { get; }

		// @property (readonly, nonatomic) NSDictionary * diffData;
		[Export("diffData")]
		NSDictionary DiffData { get; }

		// @property (copy, nonatomic) SonicURLProtocolCallBack protocolCallBack;
		[Export("protocolCallBack", ArgumentSemantic.Copy)]
		SonicURLProtocolCallBack ProtocolCallBack { get; set; }

		[Wrap("WeakDelegate")]
		SonicSessionDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<SonicSessionDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * delegateId;
		[Export("delegateId")]
		string DelegateId { get; set; }

		// @property (copy, nonatomic) SonicSessionCompleteCallback completionCallback;
		[Export("completionCallback", ArgumentSemantic.Copy)]
		SonicSessionCompleteCallback CompletionCallback { get; set; }

		// @property (assign, nonatomic) BOOL isDataFetchFinished;
		[Export("isDataFetchFinished")]
		bool IsDataFetchFinished { get; set; }

		// @property (assign, nonatomic) SonicStatusCode sonicStatusCode;
		[Export("sonicStatusCode", ArgumentSemantic.Assign)]
		SonicStatusCode SonicStatusCode { get; set; }

		// @property (copy, nonatomic) SonicWebviewCallBack webviewCallBack;
		[Export("webviewCallBack", ArgumentSemantic.Copy)]
		SonicWebviewCallBack WebviewCallBack { get; set; }

		// @property (copy, nonatomic) NSString * serverIP;
		[Export("serverIP")]
		string ServerIP { get; set; }

		// @property (readonly, nonatomic) SonicSessionConfiguration * configuration;
		[Export("configuration")]
		SonicSessionConfiguration Configuration { get; }

		// +(BOOL)registerSonicConnection:(Class)connectionClass;
		[Static]
		[Export("registerSonicConnection:")]
		bool RegisterSonicConnection(Class connectionClass);

		// +(void)unregisterSonicConnection:(Class)connectionClass;
		[Static]
		[Export("unregisterSonicConnection:")]
		void UnregisterSonicConnection(Class connectionClass);

		// +(NSOperationQueue *)sonicSessionQueue;
		[Static]
		[Export("sonicSessionQueue")]
		//[Verify(MethodToProperty)]
		NSOperationQueue SonicSessionQueue { get; }

		// -(instancetype)initWithUrl:(NSString *)aUrl withWebDelegate:(id<SonicSessionDelegate>)aWebDelegate Configuration:(SonicSessionConfiguration *)aConfiguration;
		[Export("initWithUrl:withWebDelegate:Configuration:")]
		IntPtr Constructor(string aUrl, SonicSessionDelegate aWebDelegate, SonicSessionConfiguration aConfiguration);

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)cancel;
		[Export("cancel")]
		void Cancel();

		// -(void)preloadRequestActionsWithProtocolCallBack:(SonicURLProtocolCallBack)protocolCallBack;
		[Export("preloadRequestActionsWithProtocolCallBack:")]
		void PreloadRequestActionsWithProtocolCallBack(SonicURLProtocolCallBack protocolCallBack);

		// -(void)getResultWithCallBack:(SonicWebviewCallBack)webviewCallback;
		[Export("getResultWithCallBack:")]
		void GetResultWithCallBack(SonicWebviewCallBack webviewCallback);
	}

	// @interface SonicEngine : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicEngine
	{
		// @property (readonly, nonatomic) NSString * currentUserAccount;
		[Export("currentUserAccount")]
		string CurrentUserAccount { get; }

		// @property (readonly, nonatomic) NSString * userAgent;
		[Export("userAgent")]
		string UserAgent { get; }

		// @property (readonly, nonatomic) SonicConfiguration * configuration;
		[Export("configuration")]
		SonicConfiguration Configuration { get; }

		// +(SonicEngine *)sharedEngine;
		[Static]
		[Export("sharedEngine")]
		//[Verify(MethodToProperty)]
		SonicEngine SharedEngine { get; }

		// -(void)runWithConfiguration:(SonicConfiguration *)aConfiguration;
		[Export("runWithConfiguration:")]
		void RunWithConfiguration(SonicConfiguration aConfiguration);

		// -(void)setCurrentUserAccount:(NSString *)userAccount;
		[Export("setCurrentUserAccount:")]
		void SetCurrentUserAccount(string userAccount);

		// -(void)clearAllCache;
		[Export("clearAllCache")]
		void ClearAllCache();

		// -(void)removeCacheByUrl:(NSString *)url;
		[Export("removeCacheByUrl:")]
		void RemoveCacheByUrl(string url);

		// -(BOOL)isFirstLoad:(NSString *)url;
		[Export("isFirstLoad:")]
		bool IsFirstLoad(string url);

		// -(void)addDomain:(NSString *)domain withIpAddress:(NSString *)ipAddress;
		[Export("addDomain:withIpAddress:")]
		void AddDomain(string domain, string ipAddress);

		// -(void)setGlobalUserAgent:(NSString *)aUserAgent;
		[Export("setGlobalUserAgent:")]
		void SetGlobalUserAgent(string aUserAgent);

		// -(NSString *)getGlobalUserAgent;
		[Export("getGlobalUserAgent")]
		//[Verify(MethodToProperty)]
		string GlobalUserAgent { get; }

		// -(NSString *)localRefreshTimeByUrl:(NSString *)url;
		[Export("localRefreshTimeByUrl:")]
		string LocalRefreshTimeByUrl(string url);

		// -(void)createSessionWithUrl:(NSString *)url withWebDelegate:(id<SonicSessionDelegate>)aWebDelegate withConfiguration:(SonicSessionConfiguration *)configuration;
		[Export("createSessionWithUrl:withWebDelegate:withConfiguration:")]
		void CreateSessionWithUrl(string url, ISonicSessionDelegate aWebDelegate, SonicSessionConfiguration configuration);

		// -(void)createSessionWithUrl:(NSString *)url withWebDelegate:(id<SonicSessionDelegate>)aWebDelegate;
		[Export("createSessionWithUrl:withWebDelegate:")]
		void CreateSessionWithUrl(string url, ISonicSessionDelegate aWebDelegate);

		// -(void)removeSessionWithWebDelegate:(id<SonicSessionDelegate>)aWebDelegate;
		[Export("removeSessionWithWebDelegate:")]
		void RemoveSessionWithWebDelegate(ISonicSessionDelegate aWebDelegate);

		// -(SonicSession *)sessionById:(NSString *)sessionId;
		[Export("sessionById:")]
		SonicSession SessionById(string sessionId);

		// -(SonicSession *)sessionWithWebDelegate:(id<SonicSessionDelegate>)aWebDelegate;
		[Export("sessionWithWebDelegate:")]
		SonicSession SessionWithWebDelegate(ISonicSessionDelegate aWebDelegate);

		// -(SonicSession *)sessionWithDelegateId:(NSString *)delegateId;
		[Export("sessionWithDelegateId:")]
		SonicSession SessionWithDelegateId(string delegateId);

		// -(void)sonicUpdateDiffDataByWebDelegate:(id<SonicSessionDelegate>)aWebDelegate completion:(SonicWebviewCallBack)resultBlock;
		[Export("sonicUpdateDiffDataByWebDelegate:completion:")]
		void SonicUpdateDiffDataByWebDelegate(ISonicSessionDelegate aWebDelegate, SonicWebviewCallBack resultBlock);

		// -(void)registerURLProtocolCallBackWithSessionID:(NSString *)sessionID completion:(SonicURLProtocolCallBack)protocolCallBack;
		[Export("registerURLProtocolCallBackWithSessionID:completion:")]
		void RegisterURLProtocolCallBackWithSessionID(string sessionID, SonicURLProtocolCallBack protocolCallBack);
	}

	interface ISonicSessionDelegate
	{

	}

	// @interface SonicConnection : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicConnection
	{
		// @property (retain, nonatomic) NSURLRequest * request;
		[Export("request", ArgumentSemantic.Retain)]
		NSUrlRequest Request { get; set; }

		[Wrap("WeakDelegate")]
		SonicConnectionDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<SonicConnectionDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (retain, nonatomic) NSOperationQueue * delegateQueue;
		[Export("delegateQueue", ArgumentSemantic.Retain)]
		NSOperationQueue DelegateQueue { get; set; }

		// +(BOOL)canInitWithRequest:(NSURLRequest *)request;
		[Static]
		[Export("canInitWithRequest:")]
		bool CanInitWithRequest(NSUrlRequest request);

		// -(instancetype)initWithRequest:(NSURLRequest *)aRequest delegate:(id<SonicConnectionDelegate>)delegate delegateQueue:(NSOperationQueue *)queue;
		[Export("initWithRequest:delegate:delegateQueue:")]
		IntPtr Constructor(NSUrlRequest aRequest, SonicConnectionDelegate @delegate, NSOperationQueue queue);

		// -(void)startLoading;
		[Export("startLoading")]
		void StartLoading();

		// -(void)stopLoading;
		[Export("stopLoading")]
		void StopLoading();
	}

	// @interface SonicUtil : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicUtil
	{
		// +(NSURLRequest *)sonicWebRequestWithSession:(SonicSession *)session withOrigin:(NSURLRequest *)originRequest;
		[Static]
		[Export("sonicWebRequestWithSession:withOrigin:")]
		NSUrlRequest SonicWebRequestWithSession(SonicSession session, NSUrlRequest originRequest);

		// +(NSString *)sonicUrl:(NSString *)url;
		[Static]
		[Export("sonicUrl:")]
		string SonicUrl(string url);

		// +(NSDictionary *)splitTemplateAndDataFromHtmlData:(NSString *)html;
		[Static]
		[Export("splitTemplateAndDataFromHtmlData:")]
		NSDictionary SplitTemplateAndDataFromHtmlData(string html);

		// +(NSDictionary *)mergeDynamicData:(NSDictionary *)updateDict withOriginData:(NSMutableDictionary *)existData;
		[Static]
		[Export("mergeDynamicData:withOriginData:")]
		NSDictionary MergeDynamicData(NSDictionary updateDict, NSMutableDictionary existData);
	}

	// @interface SonicURLProtocol : NSURLProtocol
	[BaseType(typeof(NSUrlProtocol))]
	interface SonicURLProtocol
	{
	}

	// @interface SonicCacheItem : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicCacheItem
	{
		// @property (retain, nonatomic) NSData * htmlData;
		[Export("htmlData", ArgumentSemantic.Retain)]
		NSData HtmlData { get; set; }

		// @property (retain, nonatomic) NSDictionary * config;
		[Export("config", ArgumentSemantic.Retain)]
		NSDictionary Config { get; set; }

		// @property (readonly, nonatomic) NSString * sessionID;
		[Export("sessionID")]
		string SessionID { get; }

		// @property (copy, nonatomic) NSString * templateString;
		[Export("templateString")]
		string TemplateString { get; set; }

		// @property (retain, nonatomic) NSDictionary * diffData;
		[Export("diffData", ArgumentSemantic.Retain)]
		NSDictionary DiffData { get; set; }

		// @property (retain, nonatomic) NSDictionary * dynamicData;
		[Export("dynamicData", ArgumentSemantic.Retain)]
		NSDictionary DynamicData { get; set; }

		// @property (readonly, nonatomic) BOOL hasLocalCache;
		[Export("hasLocalCache")]
		bool HasLocalCache { get; }

		// @property (readonly, nonatomic) NSString * lastRefreshTime;
		[Export("lastRefreshTime")]
		string LastRefreshTime { get; }

		// @property (retain, nonatomic) NSDictionary * cacheResponseHeaders;
		[Export("cacheResponseHeaders", ArgumentSemantic.Retain)]
		NSDictionary CacheResponseHeaders { get; set; }

		// -(instancetype)initWithSessionID:(NSString *)aSessionID;
		[Export("initWithSessionID:")]
		IntPtr Constructor(string aSessionID);

		// -(BOOL)isCacheExpired;
		[Export("isCacheExpired")]
		//[Verify(MethodToProperty)]
		bool IsCacheExpired { get; }
	}

	// @interface SonicCache : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicCache
	{
		// +(SonicCache *)shareCache;
		[Static]
		[Export("shareCache")]
		//[Verify(MethodToProperty)]
		SonicCache ShareCache { get; }

		// -(BOOL)setupCacheDirectory;
		[Export("setupCacheDirectory")]
		//[Verify(MethodToProperty)]
		bool SetupCacheDirectory();

		// -(void)clearAllCache;
		[Export("clearAllCache")]
		void ClearAllCache();

		// -(void)removeCacheBySessionID:(NSString *)sessionID;
		[Export("removeCacheBySessionID:")]
		void RemoveCacheBySessionID(string sessionID);

		// -(BOOL)isServerDisableSonic:(NSString *)sessionID;
		[Export("isServerDisableSonic:")]
		bool IsServerDisableSonic(string sessionID);

		// -(void)saveServerDisableSonicTimeNow:(NSString *)sessionID;
		[Export("saveServerDisableSonicTimeNow:")]
		void SaveServerDisableSonicTimeNow(string sessionID);

		// -(void)removeServerDisableSonic:(NSString *)sessionID;
		[Export("removeServerDisableSonic:")]
		void RemoveServerDisableSonic(string sessionID);

		// -(NSDictionary *)dynamicDataBySessionID:(NSString *)sessionID;
		[Export("dynamicDataBySessionID:")]
		NSDictionary DynamicDataBySessionID(string sessionID);

		// -(NSString *)templateStringBySessionID:(NSString *)sessionID;
		[Export("templateStringBySessionID:")]
		string TemplateStringBySessionID(string sessionID);

		// -(BOOL)isFirstLoad:(NSString *)sessionID;
		[Export("isFirstLoad:")]
		bool IsFirstLoad(string sessionID);

		// -(SonicCacheItem *)updateWithJsonData:(NSData *)jsonData withHtmlString:(NSString *)htmlString withResponseHeaders:(NSDictionary *)headers withUrl:(NSString *)url;
		[Export("updateWithJsonData:withHtmlString:withResponseHeaders:withUrl:")]
		SonicCacheItem UpdateWithJsonData(NSData jsonData, string htmlString, NSDictionary headers, string url);

		// -(SonicCacheItem *)saveHtmlString:(NSString *)htmlString templateString:(NSString *)templateString dynamicData:(NSDictionary *)dataDict responseHeaders:(NSDictionary *)headers withUrl:(NSString *)url;
		[Export("saveHtmlString:templateString:dynamicData:responseHeaders:withUrl:")]
		SonicCacheItem SaveHtmlString(string htmlString, string templateString, NSDictionary dataDict, NSDictionary headers, string url);

		// -(void)updateCacheExpireTimeWithResponseHeaders:(NSDictionary *)headers withSessionID:(NSString *)sessionID;
		[Export("updateCacheExpireTimeWithResponseHeaders:withSessionID:")]
		void UpdateCacheExpireTimeWithResponseHeaders(NSDictionary headers, string sessionID);

		// -(void)saveResponseHeaders:(NSDictionary *)headers withSessionID:(NSString *)sessionID;
		[Export("saveResponseHeaders:withSessionID:")]
		void SaveResponseHeaders(NSDictionary headers, string sessionID);

		// -(SonicCacheItem *)cacheForSession:(NSString *)sessionID;
		[Export("cacheForSession:")]
		SonicCacheItem CacheForSession(string sessionID);

		// -(NSString *)localRefreshTimeBySessionID:(NSString *)sessionID;
		[Export("localRefreshTimeBySessionID:")]
		string LocalRefreshTimeBySessionID(string sessionID);

		// -(void)checkAndTrimCache;
		[Export("checkAndTrimCache")]
		void CheckAndTrimCache();

		// -(BOOL)upgradeSonicVersion;
		[Export("upgradeSonicVersion")]
		//[Verify(MethodToProperty)]
		bool UpgradeSonicVersion();
	}

	// @interface SonicDatabase : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicDatabase
	{
		// -(instancetype)initWithPath:(NSString *)dbPath;
		[Export("initWithPath:")]
		IntPtr Constructor(string dbPath);

		// -(BOOL)insertWithKeyAndValue:(NSDictionary *)keyValues withSessionID:(NSString *)sessionID;
		[Export("insertWithKeyAndValue:withSessionID:")]
		bool InsertWithKeyAndValue(NSDictionary keyValues, string sessionID);

		// -(BOOL)updateWithKeyAndValue:(NSDictionary *)keyValues withSessionID:(NSString *)sessionID;
		[Export("updateWithKeyAndValue:withSessionID:")]
		bool UpdateWithKeyAndValue(NSDictionary keyValues, string sessionID);

		// -(NSDictionary *)queryAllKeysWithSessionID:(NSString *)sessionID;
		[Export("queryAllKeysWithSessionID:")]
		NSDictionary QueryAllKeysWithSessionID(string sessionID);

		// -(NSString *)queryKey:(NSString *)key withSessionID:(NSString *)sessionID;
		[Export("queryKey:withSessionID:")]
		string QueryKey(string key, string sessionID);

		// -(BOOL)clearWithSessionID:(NSString *)sessionID;
		[Export("clearWithSessionID:")]
		bool ClearWithSessionID(string sessionID);

		// -(void)close;
		[Export("close")]
		void Close();
	}

	// @interface SonicServer : NSObject
	[BaseType(typeof(NSObject))]
	interface SonicServer
	{
		// @property (readonly, nonatomic) NSMutableURLRequest * request;
		[Export("request")]
		NSMutableUrlRequest Request { get; }

		// @property (readonly, nonatomic) NSHTTPURLResponse * response;
		[Export("response")]
		NSHttpUrlResponse Response { get; }

		// @property (readonly, nonatomic) NSMutableData * responseData;
		[Export("responseData")]
		NSMutableData ResponseData { get; }

		// @property (readonly, nonatomic) NSError * error;
		[Export("error")]
		NSError Error { get; }

		// @property (readonly, nonatomic) BOOL isInLocalServerMode;
		[Export("isInLocalServerMode")]
		bool IsInLocalServerMode { get; }

		// +(BOOL)registerSonicConnection:(Class)connectionClass;
		[Static]
		[Export("registerSonicConnection:")]
		bool RegisterSonicConnection(Class connectionClass);

		// +(void)unregisterSonicConnection:(Class)connectionClass;
		[Static]
		[Export("unregisterSonicConnection:")]
		void UnregisterSonicConnection(Class connectionClass);

		// -(instancetype)initWithUrl:(NSString *)url delegate:(id<SonicServerDelegate>)delegate delegateQueue:(NSOperationQueue *)queue;
		[Export("initWithUrl:delegate:delegateQueue:")]
		IntPtr Constructor(string url, SonicServerDelegate @delegate, NSOperationQueue queue);

		// -(void)setRequestHeaderFields:(NSDictionary *)headers;
		[Export("setRequestHeaderFields:")]
		void SetRequestHeaderFields(NSDictionary headers);

		// -(void)addRequestHeaderFields:(NSDictionary *)headers;
		[Export("addRequestHeaderFields:")]
		void AddRequestHeaderFields(NSDictionary headers);

		// -(void)setResponseHeaderFields:(NSDictionary *)headers;
		[Export("setResponseHeaderFields:")]
		void SetResponseHeaderFields(NSDictionary headers);

		// -(NSString *)responseHeaderForKey:(NSString *)aKey;
		[Export("responseHeaderForKey:")]
		string ResponseHeaderForKey(string aKey);

		// -(void)enableLocalServer:(BOOL)enable;
		[Export("enableLocalServer:")]
		void EnableLocalServer(bool enable);

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)stop;
		[Export("stop")]
		void Stop();

		// -(NSDictionary *)sonicItemForCache;
		[Export("sonicItemForCache")]
		//[Verify(MethodToProperty)]
		NSDictionary SonicItemForCache { get; }
	}
}
