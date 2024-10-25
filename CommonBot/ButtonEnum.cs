using Common;
using Telegram.Bot;

namespace NozarfBot;
public static class ButtonEnum
{
    public static readonly ButtonEnumItem Return = new("بازگشت", nameof(Return).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem PlaceOrder = new("ثبت سفارش", nameof(PlaceOrder).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem Delete = new("حذف سفارش", nameof(Delete).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem Order = new("مشاهده سفارش", nameof(Order).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem Orders = new("لیست سفارشات", nameof(Orders).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem MakePayment = new("پرداخت هزینه سفارش", nameof(MakePayment).CamelCaseToKebabCase());
}