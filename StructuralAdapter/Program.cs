using RR.DesignPattern.Structural.Adapter;

Console.WriteLine("Payment Gateway");
Console.WriteLine("Value of the payment: ");
var value = Console.ReadLine();
if (string.IsNullOrEmpty(value))
    throw new ArgumentException("Value cannot be null or empty");


Console.WriteLine("Select the payment gateway");
Console.WriteLine("1 - Cielo");
Console.WriteLine("2 - Mercado Pago");
var typePayment = Console.ReadLine();
if (string.IsNullOrEmpty(typePayment))
    throw new ArgumentException("Value cannot be null or empty");

IPaymentGateway payment = int.Parse(typePayment) switch
{
    1 => new PaymentGatewayAdapterCielo(),
    2 => new PaymentGatewayAdapterMercadoPago(),
    _ => throw new ArgumentException("Invalid payment type")
};

payment.ProcessPayment("RESTAURANTE BOB ESPONJA", Decimal.Parse(value), "01.001.001/0001-01");

namespace RR.DesignPattern.Structural.Adapter
{
    public class PaymentGatewayMercadoPago
    {
        public void MakePaymentMercadoPago(string paymentInfo, decimal value, string cnpj)
        {
            Console.WriteLine($"Realizando pagamento com Mercado Pago: {paymentInfo}, {value:C}, CNPJ {cnpj}");
        }
    }

    public class PaymentGatewayCielo
    {
        public void MakePaymentCielo(string paymentInfo, decimal value)
        {
            Console.WriteLine($"Realizando pagamento com Cielo: {paymentInfo}, {value:C}");
        }
    }

    public interface IPaymentGateway
    {
        void ProcessPayment(string paymentData, decimal value, string cnpj);
    }

    public class PaymentGatewayAdapterMercadoPago : IPaymentGateway
    {
        private readonly PaymentGatewayMercadoPago _paymentGatewayMercadoPago = new();

        public void ProcessPayment(string paymentData, decimal value, string cnpj)
        {
            _paymentGatewayMercadoPago.MakePaymentMercadoPago(paymentData, value, cnpj);
        }
    }

    public class PaymentGatewayAdapterCielo : IPaymentGateway
    {
        private readonly PaymentGatewayCielo _paymentGatewayCielo = new();

        public void ProcessPayment(string paymentData, decimal value, string cnpj)
        {
            _paymentGatewayCielo.MakePaymentCielo(paymentData, value);
        }
    }
}
