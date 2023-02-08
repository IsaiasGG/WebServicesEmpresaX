namespace WebServicesEmpresaX.Model.Request
{
    public class DireccionRequest
    {
        public int DireccionID { get; set; }
        public string Calle { get; set; }
        public string Sector { get; set; }
        public string Ciudad { get; set; }
        public int ClienteID { get; set; }

    }
}
