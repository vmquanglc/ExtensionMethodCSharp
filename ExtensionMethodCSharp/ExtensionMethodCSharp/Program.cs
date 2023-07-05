// See https://aka.ms/new-console-template for more information



using ExtensionMethodCSharp;
using ExtensionMethodCSharp.Enums;

var dataCheck = "a á à ã ả ạ ă ắ ằ ẳ ẵ ặ â ấ ầ ẩ ẫ ậ o ò ó õ ỏ ọ ô ố ồ ỗ ổ ộ ơ ỡ ờ ớ ở ợ đ Đe ẹ ẽ ẻ é è ê ệ ễ ể ế ề";
var check = dataCheck.RemoveVNSignV2();

var xxx = ExchangeRateType.Fixed;
var data = xxx.GetEnumDisplayName();
Console.WriteLine("Hello, World!");
