using MudBlazor;
using QRCoder;


namespace Generador_QR.Pages
{
    public partial class Home
    {
        MudForm urlSubmitForm;
        public string SubmittedUrl { get; set; }
        public string QRCodeText { get; set; }

        private async Task SubmittedUrl()
        {
            async urlSubmitForm.Validate();
            if(urlSubmitForm.IsValid)
                GenerateQRCode();
        }


        protected void GenerateQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(SubmittedUrl, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qRCodeData);
            byte[] qrCodeAsByteArr = qrCode.GetGraphic(20);

            var ms = new MemoryStream(qrCodeAsByteArr);
            QRCodeText = "data:/image/png;base64," + Convert.ToBase64String(ms.ToArray());
            SubmittedUrl = String.Empty;
        }
    }
}
