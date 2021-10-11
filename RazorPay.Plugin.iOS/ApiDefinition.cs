﻿using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Com.RazorPay
{
	[Protocol(Name = "ExternalWalletSelectionProtocol")]
	[BaseType(typeof(NSObject))]
	interface ExternalWalletSelectionProtocol
	{
		// @required -(void)onExternalWalletSelected:(NSString * _Nonnull)walletName withPaymentData:(NSDictionary * _Nullable)paymentData;
		[Abstract]
		[Export("onExternalWalletSelected:withPaymentData:")]
		void WithPaymentData(string walletName, [NullAllowed] NSDictionary paymentData);
	}

	// @interface Otpelf : NSObject
	[BaseType(typeof(NSObject), Name = "RazorpayOtpelf")]
	[DisableDefaultCtor]
	[Protocol]
	interface Otpelf
	{
		// +(void)initWithWebView:(WKWebView * _Nonnull)webView andMerchantKey:(NSString * _Nullable)merchantKey __attribute__((objc_method_family("none")));
		[Static]
		[Export("initWithWebView:andMerchantKey:")]
		void InitWithWebView(WKWebView webView, [NullAllowed] string merchantKey);

		// +(Otpelf * _Nullable)getSharedInstance __attribute__((warn_unused_result));
		[Static]
		[NullAllowed, Export("getSharedInstance")]
		Otpelf SharedInstance { get; }

		// -(void)setPaymentData:(NSDictionary * _Nonnull)data;
		[Export("setPaymentData:")]
		void SetPaymentData(NSDictionary data);

		// -(BOOL)webViewWithDidFinish:(WKNavigation * _Null_unspecified)navigation error:(NSError * _Nullable * _Nullable)error;
		[Export("webViewWithDidFinish:error:")]
		bool WebViewWithDidFinish(WKNavigation navigation, [NullAllowed] out NSError error);

		// -(void)close;
		[Export("close")]
		void Close();
	}

	// @protocol PluginPaymentDelegate
	[Protocol(Name = "PluginPaymentDelegate"), Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface PluginPaymentDelegate
	{
		// @required -(BOOL)canProcessPaymentWithModel:(PluginPaymentModel * _Nonnull)model __attribute__((warn_unused_result));
		[Abstract]
		[Export("canProcessPaymentWithModel:")]
		bool CanProcessPaymentWithModel(PluginPaymentModel model);

		// @required -(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Abstract]
		[Export("identifier")]
		string Identifier { get; }

		// @required -(void)payWithModel:(PluginPaymentModel * _Nonnull)model;
		[Abstract]
		[Export("payWithModel:")]
		void PayWithModel(PluginPaymentModel model);
	}

	// @interface PluginPaymentModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC8Razorpay18PluginPaymentModel")]
	[DisableDefaultCtor]
	[Protocol]
	interface PluginPaymentModel
	{
	}

	// @interface Razorpay : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC8Razorpay8Razorpay")]
	[DisableDefaultCtor]
	[Protocol]
	interface Razorpay
	{
		// +(Razorpay * _Nonnull)initWithKey:(NSString * _Nonnull)key andDelegate:(id<RazorpayPaymentCompletionProtocol> _Nonnull)delegate __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result));
		[Static]
		[Export("initWithKey:andDelegate:")]
		Razorpay InitWithKey(string key, RazorpayPaymentCompletionProtocol @delegate);

		// +(Razorpay * _Nonnull)initWithKey:(NSString * _Nonnull)key andDelegateWithData:(id<RazorpayPaymentCompletionProtocolWithData> _Nonnull)delegate __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result));
		[Static]
		[Export("initWithKey:andDelegateWithData:")]
		Razorpay InitWithKey(string key, RazorpayPaymentCompletionProtocolWithData @delegate);

		// -(void)setExternalWalletSelectionDelegate:(id<ExternalWalletSelectionProtocol> _Nonnull)walletDelegate;
		[Export("setExternalWalletSelectionDelegate:")]
		void SetExternalWalletSelectionDelegate(ExternalWalletSelectionProtocol walletDelegate);

		// -(void)open:(NSDictionary * _Nonnull)options displayController:(UIViewController * _Nonnull)displayController;
		[Export("open:displayController:")]
		void Open(NSDictionary options, UIViewController displayController);

		// -(void)open:(NSDictionary * _Nonnull)options;
		[Export("open:")]
		void Open(NSDictionary options);

		// -(void)open:(NSDictionary * _Nonnull)options displayController:(UIViewController * _Nonnull)displayController arrExternalPaymentEntities:(NSArray<id<PluginPaymentDelegate>> * _Nonnull)arrExternalPaymentEntities;
		[Export("open:displayController:arrExternalPaymentEntities:")]
		void Open(NSDictionary options, UIViewController displayController, PluginPaymentDelegate[] arrExternalPaymentEntities);

		// -(void)open:(NSDictionary * _Nonnull)options arrExternalPaymentEntities:(NSArray<id<PluginPaymentDelegate>> * _Nonnull)arrExternalPaymentEntities;
		[Export("open:arrExternalPaymentEntities:")]
		void Open(NSDictionary options, PluginPaymentDelegate[] arrExternalPaymentEntities);

		// -(void)close;
		[Export("close")]
		void Close();
	}

	// @protocol RazorpayPaymentCompletionProtocol
	/*
	  Check whether adding [Model] to this declaration is appropriate.
	  [Model] is used to generate a C# class that implements this protocol,
	  and might be useful for protocols that consumers are supposed to implement,
	  since consumers can subclass the generated class instead of implementing
	  the generated interface. If consumers are not supposed to implement this
	  protocol, then [Model] is redundant and will generate code that will never
	  be used.
	*/
	[Protocol(Name = "RazorpayPaymentCompletionProtocol"), Model]
	[BaseType(typeof(NSObject))]
	interface RazorpayPaymentCompletionProtocol
	{
		// @required -(void)onPaymentError:(int32_t)code description:(NSString * _Nonnull)str __attribute__((deprecated("this function will accept a code of Type Int and not Int32 in future releases")));

		[Export("onPaymentError:description:")]
		void OnPaymentError(int code, string str);

		// @required -(void)onPaymentSuccess:(NSString * _Nonnull)payment_id;

		[Export("onPaymentSuccess:")]
		void OnPaymentSuccess(string payment_id);
	}

	// @protocol RazorpayPaymentCompletionProtocolWithData
	/*
	  Check whether adding [Model] to this declaration is appropriate.
	  [Model] is used to generate a C# class that implements this protocol,
	  and might be useful for protocols that consumers are supposed to implement,
	  since consumers can subclass the generated class instead of implementing
	  the generated interface. If consumers are not supposed to implement this
	  protocol, then [Model] is redundant and will generate code that will never
	  be used.
	*/
	[Protocol(Name = "RazorpayPaymentCompletionProtocolWithData"), Model]
	[BaseType(typeof(NSObject))]
	interface RazorpayPaymentCompletionProtocolWithData
	{
		// @required -(void)onPaymentError:(int32_t)code description:(NSString * _Nonnull)str andData:(NSDictionary * _Nullable)response __attribute__((deprecated("this function will accept a code of Type Int and not Int32 in future releases")));

		[Export("onPaymentError:description:andData:")]
		void OnPaymentError(int code, string str, [NullAllowed] NSDictionary response);

		// @required -(void)onPaymentSuccess:(NSString * _Nonnull)payment_id andData:(NSDictionary * _Nullable)response;

		[Export("onPaymentSuccess:andData:")]
		void OnPaymentSuccess(string payment_id, [NullAllowed] NSDictionary response);
	}
}

