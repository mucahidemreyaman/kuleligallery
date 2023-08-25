namespace KuleliGallery.Shop.UI.Exceptions
{
    public class UnauthenticatedException : Exception
    {
        public UnauthenticatedException(string message):base(message)
        {

        }

        public UnauthenticatedException():base("DEVAM ETMEK İÇİN SİSTEME GİRİŞ YAPINIZ.")
        {

        }
    }
}
