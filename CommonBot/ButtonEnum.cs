using Common;
using Telegram.Bot;

namespace NozarfBot;
public static class ButtonEnum
{
    public static readonly ButtonEnumItem PlaceOrder = new("ثبت سفارش", nameof(PlaceOrder).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem EditOrder = new("ویرایش سفارش", nameof(EditOrder).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem SendOrder = new("ارسال سفارش", nameof(SendOrder).CamelCaseToKebabCase());
    public static readonly ButtonEnumItem MakePayment = new("پرداخت هزینه سفارش", nameof(MakePayment).CamelCaseToKebabCase());
}