namespace KuleliGallery.Shop.UI.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message):base(message)
        {

        }

        public UnauthorizedException():base("BU ALANA ERİŞİM YETKİNİZ BULUNMAMAKTADIR.")
        {

        }
    }
}
